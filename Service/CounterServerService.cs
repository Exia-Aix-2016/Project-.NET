using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CounterServerService
    {

        public CounterServerService()
        {
            KitchenConnection.Instance.OnreceiveEvent += new KitchenConnection.ReceiveDel(Receive);
        }
        public void Receive(byte[] data)
        {
            Console.WriteLine(Encoding.ASCII.GetString(data));
        }
        public Order[] GetOrders()
        {
            return null;
        }


    }
}
