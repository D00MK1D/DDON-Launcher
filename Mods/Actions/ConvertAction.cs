#nullable enable

using System.IO.Compression;
using System.Text;
using Arrowgene.Buffers;
using Arrowgene.Ddon.Client.Resource.Texture.Dds;
using Arrowgene.Ddon.Client.Resource.Texture.Tex;
using Arrowgene.Ddon.Client.Resource.Texture;
using Arrowgene.Ddon.Client;
using System.Text.Json;

namespace DDO_Launcher.Mods.Actions
{
    public class ConvertAction : ReplaceAction
    {
        public override string Action => "convert";

        protected override byte[] LoadSourceBytes(ZipArchive zip, ArcArchive? arc, JsonElement action, ZipArchiveEntry srcZipEntry)
        {
            // Load the source bytes as a DDS file
            byte[] bytes = base.LoadSourceBytes(zip, arc, action, srcZipEntry);

            var data = new byte[srcZipEntry.Length];
            srcZipEntry.Open().ReadExactly(data);
            var ddsBuffer = new StreamBuffer(data);
            DdsTexture ddsTexture = new DdsTexture();
            ddsTexture.Open(ddsBuffer);

            string txt = action.GetProperty("txt").GetString() ?? throw new Exception("\"txt\" property is null"); ;
            TexHeader originalTexHeader;
            try
            {
                var entry = zip.Entries.Where(e => e.FullName == txt).Single();
                var sr = new StreamReader(entry.Open(), Encoding.UTF8);
                string txtContents = sr.ReadToEnd();
                originalTexHeader = TexConvert.ReadTexHeaderDump(txtContents);
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't read the original TEX headers from " + txt + " in the mod archive.\n\n" +
                                    "Error: " + ex.Message);
            }

            TexTexture texTexture = TexConvert.ToTexTexture(ddsTexture, originalTexHeader);
            var texBuffer = new StreamBuffer();
            texTexture.Write(texBuffer);
            return texBuffer.GetAllBytes();
        }
    }
}
