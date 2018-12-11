using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CounterClientService: Service
    {
        private DiningRoom _diningRoom => _injector.Get<DiningRoom>();

        public CounterClientService(DependencyInjector injector): base(injector)
        {
            DinnerConnection.Instance.OnreceiveEvent += new DinnerConnection.ReceiveDel(Receive);
        }

        public void Receive(byte[] data)
        {
            Model.MessageSocket MessageSocket = Model.Counter.Deserialize<Model.MessageSocket>(data);

            if (MessageSocket.HasMeals) _diningRoom.Counter.AddMeals(MessageSocket.Meals);
        }

        public Meal[] TakeMeals()
        {
            return _diningRoom.Counter.TakeMeals();
        }
      
        public void PutOrders(Order[] orders)
        {
            MessageSocket message = new MessageSocket(orders);
            DinnerConnection.Instance.Send(message);
        }
    }
}
