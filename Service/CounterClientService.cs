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
            DinnerConnection.Instance.OnreceiveEvent += new DinnerConnection.ReceiveDel(Receive);
        }

        public void Receive(byte[] data)
        {
            Console.WriteLine(Model.Counter.Deserialize<Model.MessageSocket>(data).ToString());
        }
        public Meal[] GetMeals()
        {
            return null;
        }
    }
}
