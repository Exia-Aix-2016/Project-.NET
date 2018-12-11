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
            Console.WriteLine(Model.Counter.Deserialize<Model.MessageSocket>(data).ToString());
        }
        public Order[] GetOrders()
        {
            return null;
        }


    }
}
