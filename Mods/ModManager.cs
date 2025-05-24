#nullable enable

using System.IO.Compression;
using System.Text.Json;
using Arrowgene.Ddon.Client;
using DDO_Launcher.Mods.Actions;

namespace DDO_Launcher.Mods
{
    public class ModManager
    {
        private static readonly ModAction[] modActions = [
            new ReplaceAction(),
            new ConvertAction()
        ];

        public async Task InstallMod(string path, IProgress<ModInstallProgress> progress)
        {
            using (var selectedModFilePath = File.OpenRead(path))
            using (var zip = new ZipArchive(selectedModFilePath, ZipArchiveMode.Read))
            {
                string name, author;
                int arcsCount;
                JsonElement.ArrayEnumerator arcsEnumerator;
                try
                {
                    JsonDocument manifest;
                    var manifestFile = zip.Entries.Where(e => e.FullName == "manifest.json").Single();
                    using (var stream = manifestFile.Open())
                    {
                        manifest = JsonDocument.Parse(stream);
                    }

                    name = manifest.RootElement.GetProperty("name").GetString() ?? throw new Exception("\"name\" property is null");
                    author = manifest.RootElement.GetProperty("author").GetString() ?? throw new Exception("\"author\" property is null");
                    var arcs = manifest.RootElement.GetProperty("arcs");
                    arcsCount = arcs.GetArrayLength();
                    arcsEnumerator = arcs.EnumerateArray();
                }
                catch (Exception ex)
                {
                    throw new Exception("Couldn\'t find manifest.json in the mod archive.\n\n" +
                                        "Make sure the mod archive is a zip file that contains a valid manifest.json file with the \"name\", \"author\", and \"arcs\" list.\n\n" +
                                        "Error: " + ex.Message);
                }

                int actionsCount = 0;
                foreach (var arc in arcsEnumerator)
                {
                    actionsCount += arc.GetProperty("actions").GetArrayLength();
                }

                await Task.Run(() =>
                {
                    int processedArcs = 0;
                    int processedTotalActions = 0;
                    int processedCurrentArcActions = 0;
                    try
                    {
                        foreach (var arc in arcsEnumerator)
                        {
                            processedCurrentArcActions = 0;

                            ArcArchive? archive;
                            string? arcProperty = arc.GetProperty("arc").GetString();
                            if (arcProperty == null)
                            {
                                archive = null;
                            }
                            else
                            {
                                string pathToArcFile = ValidateFileSystemPath(Path.Combine("nativePC/rom/", arcProperty));
                                archive = new ArcArchive();
                                archive.Open(pathToArcFile);
                                if (archive.MagicTag == null)
                                {
                                    throw new Exception("Couldn\'t open " + arcProperty + "\n" +
                                                        "Make sure the path is relative to the rom folder\n" +
                                                        "(e.g. \"ui/gui_cmn.arc\" instead of \"nativePC/rom/ui/gui_cmn.arc\"))");
                                }                             
                            }

                            var actionsProperty = arc.GetProperty("actions");
                            int currentArcActionCount = actionsProperty.GetArrayLength();
                            foreach (var action in actionsProperty.EnumerateArray())
                            {
                                ModAction? modAction = null;
                                string actionProperty = action.GetProperty("action").GetString() ?? throw new Exception("\"action\" property is null");
                                foreach (var candidate in modActions)
                                {
                                    if (candidate.Action == actionProperty)
                                    {
                                        modAction = candidate;
                                        break;
                                    }
                                }

                                if (modAction == null)
                                {
                                    throw new Exception("Unrecognized action: " + actionProperty);
                                }

                                modAction.Execute(zip, archive, action);

                                processedCurrentArcActions++;
                                processedTotalActions++;

                                progress.Report(new ModInstallProgress
                                {
                                    Name = name,
                                    Author = author,
                                    ArcCount = arcsCount,
                                    CurrentArcActionCount = currentArcActionCount,
                                    TotalActionCount = actionsCount,
                                    ProcessedArcs = processedArcs,
                                    ProcessedCurrentArcActions = processedCurrentArcActions,
                                    ProcessedTotalActions = processedTotalActions
                                });
                            }

                            processedArcs++;

                            if (archive != null)
                            {
                                byte[] savedArc = archive.Save();
                                File.WriteAllBytes(archive.FilePath.FullName, savedArc);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"On arc {processedArcs+1}, action {processedCurrentArcActions+1}:\n" + ex.Message);
                    }
                });
            }
        }

        public static string ValidateFileSystemPath(string path)
        {
            if (Path.IsPathRooted(path) || Path.GetFullPath(path).StartsWith(Path.GetFullPath(AppContext.BaseDirectory)))
            {
                throw new Exception("Invalid path: "+path+"\nThe path must be relative to the launcher directory.");
            }
            return path;
        }
    }

    public struct ModInstallProgress
    {
        public string Name;
        public string Author;

        public int ArcCount;
        public int CurrentArcActionCount;
        public int TotalActionCount;

        public int ProcessedArcs;
        public int ProcessedCurrentArcActions;
        public int ProcessedTotalActions;
    }
}
