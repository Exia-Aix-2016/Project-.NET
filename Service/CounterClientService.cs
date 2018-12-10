using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CounterClientService
    {
  
        public CounterClientService()
        {
            DinnerConnection.Instance.OnreceiveEvent += new DinnerConnection.ReceiveDel(receive);
        }

        public void receive(byte[] data)
        {
            Console.WriteLine(Model.Counter.Deserialize<string>(data));
        }
        public Meal[] GetMeals()
        {
            return null;
        }
    }
}
