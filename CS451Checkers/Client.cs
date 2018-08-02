using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CS451Checkers.Networking
{
    class Client
    {
        bool socketReady;
        public string clientName;
        TcpClient socket;
        NetworkStream stream;
        StreamWriter writer;
        StreamReader reader;
        List<GameClient> Players = new List<GameClient>();
        //public Caved.NetworkPlayer player;
        public bool Host;
        public Client Opponent;
        string host;
        int port;

        public string Name;

        void Update()
        {
            if (socketReady)
            {
                if (stream.DataAvailable)
                {
                    string data = reader.ReadLine();
                    if (data != null)
                    {
                        OnIncomingData(data);
                    }
                }
            }
            if (!socket.Connected)
            {
                ConnectToServer(host, port);
            }


        }

        public bool ConnectToServer(string host, int port)
        {
            if (socketReady) { return false; }

            try
            {
                socket = null;
                socket = new TcpClient(host, port);
                stream = socket.GetStream();
                writer = new StreamWriter(stream);
                reader = new StreamReader(stream);

                socketReady = true;
                this.host = host;
                this.port = port;

            }
            catch (Exception e)
            {

            }

            return socketReady;
        }

        void OnIncomingData(string data)
        {
            string[] aData = data.Split('|');
        }

        public void Send(string data)
        {
            if (!socketReady)
            {
                return;
            }
            writer.WriteLine(data);
            writer.Flush();
        }

        public void CloseSocket()
        {
            if (!socketReady)
            {
                return;
            }

            writer.Close();
            reader.Close();
            socket.Close();
            socketReady = false;
        }

        void OnIncominngData(ServerClient c, string data)
        {
            OnIncomingData(data);
        }

        void UserConnected(string Name, bool Host)
        {
            if (Name == "" || Players.Any(x => x.name == Name)) { return; }
            GameClient c = new GameClient();
            c.name = Name;
            Players.Add(c);

            
            if (!GameManager.Instance.Clients.Any(x => x.clientName == Name))
            {
                Client C = new Client();
                C.clientName = Name;
                GameManager.Instance.Clients.Add(C);
            }
            if (Players.Count == 2)
            {
                GameManager.Instance.StartGame();
            }
            
        }

    }

    public class GameClient
    {
        public string name;
        public bool isHost;
    }
}
