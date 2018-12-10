﻿using System;
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
        private Thread thread;
        IPEndPoint localpt = new IPEndPoint(IPAddress.Loopback, 6000);

        private static readonly Lazy<DinnerConnection> lazy = new Lazy<DinnerConnection>(() => new DinnerConnection());

        public static DinnerConnection Instance { get => lazy.Value; }


        private DinnerConnection()
        {
            client = new UdpClient();
            thread = new Thread(Read);
            client.Client.SetSocketOption(
            SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.Client.Bind(localpt);
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
            client.Send(data, data.Length, localpt);
        }

        public byte[] Receive()
        {
            IPEndPoint source = null;
            return client.Receive(ref source);
        }

    }
}

