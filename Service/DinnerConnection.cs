using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public sealed class DinnerConnection : Model.IConnection
    {
        public delegate void ReceiveDel(byte[] data);
        public event ReceiveDel OnreceiveEvent;

        private UdpClient client;
        private UdpClient server;
        private Thread thread;
        IPEndPoint localpt = new IPEndPoint(IPAddress.Loopback, 2000);

        private static readonly Lazy<DinnerConnection> lazy = new Lazy<DinnerConnection>(() => new DinnerConnection());

        public static DinnerConnection Instance { get => lazy.Value; }


        private DinnerConnection()
        {
            client = new UdpClient(2001);
            server = new UdpClient();
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //client.Client.Bind(localpt);
            thread = new Thread(Read);
        }

        private void Read()
        {
            while (true)
            {
                OnreceiveEvent(Receive());    
            }
        }

        public void Start()
        {
            thread.Start(); 
        }
        public void CloseConnection()
        {
            client.Close();
        }
        public void Send<TData>(TData obj)
        {
            byte[] data = Model.Counter.Serialize<TData>(obj);
            server.Send(data, data.Length, "127.0.0.1", 2000);
        }

        public byte[] Receive()
        {
            IPEndPoint source = null;
            return client.Receive(ref source);
        }

    }
}

