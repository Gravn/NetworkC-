using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace GNetwork
{
    public class NetworkClient
    {
        private TcpClient client = new TcpClient();
        public StreamReader sReader;
        public StreamWriter sWriter;

        public IPAddress ServerIP;
        public string dataToSend = null;


        public NetworkClient()
        { 
            
        }

        public void ConnectToServer(string ServerIP)
        {
            client.Connect(ServerIP, 24567);    
        }

        public void ConnectToServer(string ServerIP, int port)
        {
            client.Connect(ServerIP, port);
        }

        public void HandleCommunication()
        {
            if (dataToSend != null)
            {
                sWriter.WriteLine(dataToSend);
                sWriter.Flush();
            }
        }
    }


    //Network servers send and recieve data from connected clients. Handles all traffic between clients.
    public class NetWorkServer
    {

        private const int port = 24567;
        private static string udpIP;
        
        public NetWorkServer()
        {
            Setup();
        }


        public void Setup()
        { 

        }

        public void Update()
        { 
            
        }

        public void ConnectClient()
        {
            
        }
    }

    public class MasterServer
    {
        public MasterServer()
        { 
            
        }
    }

    public class Peer
    {
        public Peer()
        { 
            
        }
    }
}
