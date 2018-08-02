using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CS451Checkers.Networking
{
    class GameManager
    {
        public static GameManager Instance { get; set; }

        public string ClientName;


        public Server server;

        public static int portNumber = 6321;

        public List<Client> Clients = new List<Client>();

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        public void ConnectButton()
        {
            

        }

        public void HostButton()
        {

            try
            {
                Server s = new Server();
                s.Init();
                server = s;

                Client c = new Client();
                Clients.Add(c);
                c.clientName = ClientName;
                if (c.clientName == "") { c.clientName = "Host"; }
                c.ConnectToServer(LocalIPAddress().ToString(), portNumber);
                Trace.WriteLine(c.Name + " connected");
                
            }
            catch (Exception e)
            {
                Trace.WriteLine("Error Hosting");
            }

        }

        public void ConnectToServerButton(string address)
        {
            string hostAdress = address;
            if (hostAdress == "")
            {
                hostAdress = "127.0.0.1";
            }

            try
            {
                Client c = new Client();
                c.clientName = ClientName;
                Clients.Add(c);
                c.ConnectToServer(hostAdress, portNumber);
                
            }
            catch (Exception e)
            {
                Trace.WriteLine("Error connecting to server");
                Trace.WriteLine(e);
            }
        }

        public IPAddress LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }

        public void StartGame()
        {
            Trace.WriteLine("Game Start");
        }


    }
}
