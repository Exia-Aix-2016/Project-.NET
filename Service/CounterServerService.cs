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
        private DependencyInjector injector;
        private Counter counter => injector.Get<Counter>();
        public CounterServerService(DependencyInjector dependency)
        {
            KitchenConnection.Instance.OnreceiveEvent += new KitchenConnection.ReceiveDel(Receive);
            injector = dependency;
        }
        public void Receive(byte[] data)
        {
           MessageSocket message =  Model.Counter.Deserialize<Model.MessageSocket>(data);

            if (message.HasOrders) counter.AddOrders(message.Orders);

            /*TEMPORAIRE*/
            List<Meal> meals = new List<Meal>();          
            message.Orders.ToList().ForEach(order => meals.Add(new Meal(order.Recipe)));
            PutMeals(meals.ToArray());
            /*TEMPORAIRE*/

            Console.WriteLine("TESTKITCHEN");
        }
        public Order[] GetOrders()
        {
            return counter.TakeOrders();
        }

        public void PutMeals(Meal[] meals)
        {
            MessageSocket message = new MessageSocket(meals);
            KitchenConnection.Instance.Send(message);
        }
      
    }
}
