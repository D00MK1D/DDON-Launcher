#nullable enable

using IniParser;
using IniParser.Model;

namespace DDO_Launcher
{
    public class ServerManager
    {
        private static readonly string SELECTED_SERVER_SECTION = "General";

        private static readonly string LOBBY_IP_KEY = "LobbyIP";
        private static readonly string LOBBY_PORT_KEY = "LPort";
        private static readonly string DOWNLOAD_IP_KEY = "DLIP";
        private static readonly string DOWNLOAD_PORT_KEY = "DLPort";

        private static readonly string BACKWARDS_COMPAT_DEFAULT_SERVER_NAME = "DDOn";

        public string? SelectedServer { get; private set; }
        public Dictionary<string, Server> Servers { get; private set; }

        private FileIniDataParser Parser = new FileIniDataParser();

        private readonly string ServersFile;

        public ServerManager(string serversFile)
        {
            ServersFile = serversFile;
            LoadServers();
        }

        public void SelectServer(string name)
        {
            if (!Servers.ContainsKey(name))
            {
                throw new ArgumentException("Server not found");
            }
            SelectedServer = name;
        }

        public void AddServer(string name, Server server)
        {
            Servers.Add(name, server);
            if(SelectedServer == null)
            {
                SelectServer(name);
            }
        }

        public void RemoveServer(string name)
        {
            Servers.Remove(name);
            if (name == SelectedServer)
            {
                SelectedServer = null;
            }
        }

        public void RenameServer(string oldName, string newName)
        {
            Server server = Servers[oldName];
            Servers.Remove(oldName);
            Servers.Add(newName, server);
            
            if (oldName == SelectedServer)
            {
                SelectServer(newName);
            }
        }

        public void LoadServers()
        {
            if (File.Exists(ServersFile))
            {
                IniData data = Parser.ReadFile(ServersFile);

                Servers = data.Sections
                    .Where(section => section.SectionName != SELECTED_SERVER_SECTION)
                    .ToDictionary(section => section.SectionName, section => new Server
                    {
                        LobbyIP = data[section.SectionName][LOBBY_IP_KEY],
                        LPort = ushort.Parse(data[section.SectionName][LOBBY_PORT_KEY]),
                        DLIP = data[section.SectionName][DOWNLOAD_IP_KEY],
                        DLPort = ushort.Parse(data[section.SectionName][DOWNLOAD_PORT_KEY])
                    });

                SelectedServer = Servers
                    .Where(server => server.Value.LobbyIP == data[SELECTED_SERVER_SECTION][LOBBY_IP_KEY] &&
                                    server.Value.LPort == ushort.Parse(data[SELECTED_SERVER_SECTION][LOBBY_PORT_KEY]) &&
                                    server.Value.DLIP == data[SELECTED_SERVER_SECTION][DOWNLOAD_IP_KEY] &&
                                    server.Value.DLPort == ushort.Parse(data[SELECTED_SERVER_SECTION][DOWNLOAD_PORT_KEY]))
                    .Select(server => server.Key)
                    .SingleOrDefault();

                if (SelectedServer == null && data.Sections.ContainsSection(SELECTED_SERVER_SECTION))
                {
                    // Backwards compatibility with the old launcher
                    Server server = new Server
                    {
                        LobbyIP = data[SELECTED_SERVER_SECTION][LOBBY_IP_KEY],
                        LPort = ushort.Parse(data[SELECTED_SERVER_SECTION][LOBBY_PORT_KEY]),
                        DLIP = data[SELECTED_SERVER_SECTION][DOWNLOAD_IP_KEY],
                        DLPort = ushort.Parse(data[SELECTED_SERVER_SECTION][DOWNLOAD_PORT_KEY])
                    };
                    Servers.Add(BACKWARDS_COMPAT_DEFAULT_SERVER_NAME, server);
                    SelectedServer = BACKWARDS_COMPAT_DEFAULT_SERVER_NAME;
                }
            }
        }

        public void SaveServers()
        {
            IniData data = new IniData();
            foreach (var server in Servers)
            {
                data[server.Key][LOBBY_IP_KEY] = server.Value.LobbyIP;
                data[server.Key][LOBBY_PORT_KEY] = server.Value.LPort.ToString();
                data[server.Key][DOWNLOAD_IP_KEY] = server.Value.DLIP;
                data[server.Key][DOWNLOAD_PORT_KEY] = server.Value.DLPort.ToString();
            }

            if(SelectedServer != null)
            {
                data[SELECTED_SERVER_SECTION][LOBBY_IP_KEY] = Servers[SelectedServer].LobbyIP;
                data[SELECTED_SERVER_SECTION][LOBBY_PORT_KEY] = Servers[SelectedServer].LPort.ToString();
                data[SELECTED_SERVER_SECTION][DOWNLOAD_IP_KEY] = Servers[SelectedServer].DLIP;
                data[SELECTED_SERVER_SECTION][DOWNLOAD_PORT_KEY] = Servers[SelectedServer].DLPort.ToString();
            }

            Parser.WriteFile(ServersFile, data);
        }
    }

    public class Server
    {
        public string LobbyIP = "";
        public ushort LPort = 52100;
        public string DLIP = "";
        public ushort DLPort = 52099;
    }
}
