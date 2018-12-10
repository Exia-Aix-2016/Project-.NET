using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class KitchenConnection : Model.IConnection
    {
        private static readonly Lazy<KitchenConnection> lazy = new Lazy<KitchenConnection>(() => new KitchenConnection());
        public delegate void ReceiveDel(byte[] data);
        public event ReceiveDel OnreceiveEvent;

        private UdpClient server;
        private Thread thread;
        IPEndPoint localpt = new IPEndPoint(IPAddress.Loopback, 6000);

        public static KitchenConnection Instance { get => lazy.Value; }


        private KitchenConnection()
        {
            server = new UdpClient();
            server.Client.SetSocketOption(
            SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            server.Client.Bind(localpt);
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
        public void Send<TData>(TData obj)
        {
            byte[] data = Model.Counter.Serialize<TData>(obj);
            server.Send(data, data.Length, localpt);
        }

        public byte[] Receive()
        {
            IPEndPoint source = null;
            return server.Receive(ref source);
        }

        public void CloseConnection()
        {
            server.Close();
        }
    }
}
