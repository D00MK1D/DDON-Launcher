using System.IO.Compression;
using System.Text.Json;
using Arrowgene.Ddon.Client;
using Arrowgene.Ddon.Shared.Csv;

namespace DDO_Launcher.Mods.Actions
{
    public class PackGmdAction : ModAction
    {
        public override string Action => "packGmd";

        public override void Execute(ZipArchive zip, ArcArchive? arc, JsonElement action)
        {
            if (arc != null)
            {
                throw new Exception(Action + " actions can't be done within an arc as they affect multiple arc files.");
            }

            string gmd = action.GetProperty("gmd").GetString() ?? throw new Exception("\"gmd\" property is null");
            ZipArchiveEntry srcZipEntry;
            try
            {
                srcZipEntry = zip.Entries.Where(e => e.FullName == gmd).Single();
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't find " + gmd + " in the mod archive.\n\n" +
                                    "Error: " + ex.Message);
            }

            string romLang;
            if (action.TryGetProperty("romLang", out JsonElement romLangElement) && romLangElement.GetString() != null)
            {
                romLang = romLangElement.GetString() ?? throw new Exception("\"romLang\" property is null");
            }
            else
            {
                romLang = "English"; // Default language if not specified
            }

            try
            {
                List<GmdCsv.Entry> gmdCsvEntries;
                GmdCsv gmdCsvReader = new GmdCsv();
                using (var stream = srcZipEntry.Open())
                {
                    gmdCsvEntries = gmdCsvReader.Read(stream);
                }
                GmdActions.Pack(gmdCsvEntries, "nativePC/rom", romLang);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to patch GMD files using " + gmd + "\n\n" +
                                    "Error: " + ex.Message);
            }
        }
    }
}
