#nullable enable

using System.IO.Compression;
using System.Text.Json;
using Arrowgene.Ddon.Client;
using static Arrowgene.Ddon.Client.ArcArchive;

namespace DDO_Launcher.Mods.Actions
{
    public class ReplaceAction : ModAction
    {
        public override string Action => "replace";

        public override void Execute(ZipArchive zip, ArcArchive? arc, JsonElement action)
        {
            string src = action.GetProperty("src").GetString() ?? throw new Exception("\"src\" property is null");
            ZipArchiveEntry srcZipEntry;
            try
            {
                srcZipEntry = zip.Entries.Where(e => e.FullName == src).Single();
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't find " + src + " in the mod archive.\n\n" +
                                    "Error: " + ex.Message);
            }

            string dst = action.GetProperty("dst").GetString() ?? throw new Exception("\"dst\" property is null");

            bool create;
            try
            {
                create = action.GetProperty("create").GetBoolean();
            }
            catch (KeyNotFoundException)
            {
                create = false;
            }

            if (arc == null)
            {
                string dstFilePath = ModManager.ValidateFileSystemPath(Path.Combine("nativePC/", dst));
                byte[] sourceBytes = LoadSourceBytes(zip, arc, action, srcZipEntry);
                if (!create && !File.Exists(dstFilePath))
                {
                    throw new Exception("The destination file " + dst + " does not exist and the \"create\" property is set to false.\n" +
                                        "If you want to create the file, set \"create\" to true in the action.");
                }
                try
                {
                    File.WriteAllBytes(dstFilePath, sourceBytes);
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to write the contents of "+src+" to " + dst + "\n\n" +
                                        "Error: " + ex.Message);
                }
            }
            else
            {
                int lastDotIndex = dst.LastIndexOf('.');
                string dstArcPath = dst;
                string? dstExtension = null;
                if (lastDotIndex != -1)
                {
                    dstArcPath = dst.Substring(0, lastDotIndex);
                    dstExtension = dst.Substring(lastDotIndex + 1);
                }
                FileIndexSearch search = Search()
                    .ByArcPath(dstArcPath)
                    .ByExtension(dstExtension);
                List<ArcFile> result = arc.GetFiles(search);
                if (result.Count == 0 && create)
                {
                    if (dstExtension == null)
                    {
                        throw new Exception("Can't create inside the arc " + arc.FilePath + " the new file " + dst + "\n" +
                                            "Missing extension. Make sure the destination path has one");
                    }
                    arc.PutFile(dstArcPath, dstExtension, LoadSourceBytes(zip, arc, action, srcZipEntry));
                }
                else
                {
                    ArcFile dstArcFile;
                    try
                    {
                        dstArcFile = result.Single();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Couldn't find or found more than one file with filename " + dst + " in the ARC " + arc.FilePath + ".\n\n" +
                                            "Make sure the path separator is an escaped backward slash (\\\\)\n" +
                                            "Include the destination file's extension to dissambiguate between files with the same name\n" +
                                            "(e.g. \"ui\\\\00_font\\\\button_win_00_ID_HQ.tex\" instead of \"ui/00_font/button_win_00_ID_HQ.tex\")\n" +
                                            "If you want to create the file, set \"create\" to true in the action.\n\n" +
                                            "Error: " + ex.Message);
                    }
                    dstArcFile.Data = LoadSourceBytes(zip, arc, action, srcZipEntry);
                }                
            }
        }

        protected virtual byte[] LoadSourceBytes(ZipArchive zip, ArcArchive? arc, JsonElement action, ZipArchiveEntry srcZipEntry)
        {
            byte[] bytes = new byte[srcZipEntry.Length];
            srcZipEntry.Open().ReadExactly(bytes);
            return bytes;
        }
    }
}
