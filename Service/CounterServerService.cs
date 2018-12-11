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
        private Kitchen _kitchen;
        public CounterServerService(DependencyInjector dependency)
        {
            KitchenConnection.Instance.OnreceiveEvent += new KitchenConnection.ReceiveDel(Receive);
            _kitchen = dependency.Get<Kitchen>();
        }
        public void Receive(byte[] data)
        {
           MessageSocket message =  Model.Counter.Deserialize<Model.MessageSocket>(data);

            if (message.HasOrders) _kitchen.Counter.AddOrders(message.Orders);
            if (message.HasWasheableTools) _kitchen.Counter.AddWasheableTools(message.WasheableTools);
        }
        public Order[] GetOrders()
        {
            return _kitchen.Counter.TakeOrders();
        }

        public void PutMeals(Meal[] meals)
        {
            MessageSocket message = new MessageSocket(meals);
            KitchenConnection.Instance.Send(message);
        }
        public void PutWasheableTools(WasheableTool[] washeableTools)
        {
            List<WasheableTool> tools = new List<WasheableTool>(washeableTools);
            if (tools.TrueForAll(tool => tool.CleaningStatus == CleaningStatus.CLEAN))
            {
                MessageSocket message = new MessageSocket(washeableTools);
                KitchenConnection.Instance.Send(message);
            }
        }


    }
}
