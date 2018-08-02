using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace CS451Checkers.Networking
{
    public class Server
    {
        public int port = 6321;

        List<ServerClient> clients;
        List<ServerClient> disconnectList;

        TcpListener server;
        bool ServerStarted;
        string Player1Name;

        public Board board;

        string CurrentPlayer;

        public void Init()
        {
            Player1Name = "David";
            CurrentPlayer = Player1Name;
            clients = new List<ServerClient>();
            disconnectList = new List<ServerClient>();

            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();

                StartListening();
                ServerStarted = true;
            }
            catch (Exception e)
            {
            }

        }

        public void Update()
        {
            Trace.WriteLine("Update");
            if (!ServerStarted)
            {
                return;
            }

            for (int i = 0; i < clients.Count; i++)
            {
                ServerClient c = clients[i];
                if (!IsConnected(c.tcp))
                {
                    c.tcp.Close();
                    disconnectList.Add(c);
                    continue;
                }
                else
                {
                    NetworkStream s = c.tcp.GetStream();
                    if (s.DataAvailable)
                    {
                        StreamReader reader = new StreamReader(s, true);
                        string data = reader.ReadLine();
                        if (!String.IsNullOrEmpty(data))
                        {
                            OnIncominngData(c, data);
                        }
                    }
                }
            }

            for (int i = 0; i < disconnectList.Count - 1; i++)
            {
                Broadcast("Disconnect|" + disconnectList[i], clients);
                clients.Remove(disconnectList[i]);
                disconnectList.RemoveAt(i);
            }
        }

        void StartListening()
        {
            server.BeginAcceptTcpClient(AcceptTcpClient, server);
        }

        void AcceptTcpClient(IAsyncResult ar)
        {
            TcpListener listener = (TcpListener)ar.AsyncState;
            string allUsers = "";
            foreach (ServerClient SC in clients)
            {
                allUsers += SC.ClientName + '|';

            }
            ServerClient sc = new ServerClient(listener.EndAcceptTcpClient(ar));
            clients.Add(sc);
            clients[0].ClientName = Player1Name;
            StartListening();

            Broadcast("SWHO|" + clients[0].ClientName, clients[clients.Count - 1]);
        }

        void Broadcast(string data, List<ServerClient> cl)
        {
            foreach (ServerClient sc in cl)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(sc.tcp.GetStream());
                    writer.WriteLine(data);
                    writer.Flush();
                }
                catch (Exception e)
                {
                }
            }
        }

        void Broadcast(string data, ServerClient c)
        {
            List<ServerClient> sc = new List<ServerClient> { c };
            Broadcast(data, sc);
        }

        void OnIncominngData(ServerClient c, string data)
        {

            string[] aData = data.Split('|');

            switch (aData[0])
            {
                case "Test":
                    Trace.WriteLine("Test OnIncomingData");
                    break;

                default:
                    break;
            }
        }

        bool IsConnected(TcpClient c)
        {
            try
            {
                if (c != null && c.Client != null && c.Client.Connected)
                {
                    if (c.Client.Poll(0, SelectMode.SelectRead))
                    {
                        return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);
                    }
                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }

    }

    public class ServerClient
    {
        public string ClientName;
        public TcpClient tcp;

        public ServerClient(TcpClient Tcp, string client)
        {
            tcp = Tcp;
            ClientName = client;
        }

        public ServerClient(TcpClient Tcp)
        {
            tcp = Tcp;
        }

    }

   
}
