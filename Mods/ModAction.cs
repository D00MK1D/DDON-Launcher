#nullable enable

using System.IO.Compression;
using System.Text.Json;
using Arrowgene.Ddon.Client;

namespace DDO_Launcher.Mods
{
    public abstract class ModAction
    {
        public abstract string Action { get; }
        public abstract void Execute(ZipArchive zip, ArcArchive? arc, JsonElement action);
    }
}
