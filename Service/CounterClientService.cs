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
        private DiningRoom _diningRoom;
        
  
        public CounterClientService(DependencyInjector dependencyInjector)
        {
            DinnerConnection.Instance.OnreceiveEvent += new DinnerConnection.ReceiveDel(Receive);

            _diningRoom = dependencyInjector.Get<DiningRoom>();

            

        }

        public void Receive(byte[] data)
        {
            Model.MessageSocket MessageSocket = Model.Counter.Deserialize<Model.MessageSocket>(data);

            if (MessageSocket.HasMeals) _diningRoom.Counter.AddMeals(MessageSocket.Meals);
            if (MessageSocket.HasWasheableTools) _diningRoom.Counter.AddWasheableTools(MessageSocket.WasheableTools);
            if (MessageSocket.hasCloths) _diningRoom.Counter.AddCloths(MessageSocket.Cloths);
        }
        public Meal[] TakeMeals()
        {
            return _diningRoom.Counter.TakeMeals();
        }
        public WasheableTool[] TakeWashingTools()
        {
            return _diningRoom.Counter.TakeTools(Model.CleaningStatus.CLEAN);
        }
        public void PutWashingTools(WasheableTool[] washeableTools)
        {
            List<WasheableTool> tools = new List<WasheableTool>(washeableTools);
            if (tools.TrueForAll(tool => tool.CleaningStatus == CleaningStatus.DIRTY))
            {
                MessageSocket message = new MessageSocket(washeableTools);
                DinnerConnection.Instance.Send(message);
            }
        }
        public void PutCloths(Cloth[] cloths)
        {
            List<Cloth> clths = new List<Cloth>(cloths);
            if(clths.TrueForAll(cl => cl.CleaningStatus == CleaningStatus.DIRTY))
            {
                MessageSocket message = new MessageSocket(cloths);
                DinnerConnection.Instance.Send(message);
            }

        }
        public Cloth[] TakeCloths()
        {
            return _diningRoom.Counter.TakeCloths(CleaningStatus.CLEAN);
        }
        public void PutOrders(Order[] orders)
        {
            MessageSocket message = new MessageSocket(orders);
            DinnerConnection.Instance.Send(message);
        }
    }
}
