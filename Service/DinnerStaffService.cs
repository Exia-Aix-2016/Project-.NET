using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DinnerStaffService
    {
        private DiningRoom _dining;

        public DinnerStaffService(DiningRoom dining)
        {
            _dining = dining;
        }

        public void AssignTable(Client[] clients, Table table)
        {
            HeadWaiter headWaiter = _dining.Squares
                .Where(x => x.Items().Where(y => y.Items().Contains(table)).Any())
                .Select(x => x.HeadWaiter)
                .Single();

            headWaiter.TaskProcessor.AddTask(new Model.Task(new { }, 1, x => {
                List<Client> clientsList = clients.ToList();
                table.AddItems(ref clientsList);
            }));
        }

        public HeadWaiter[] GetHeadWaiters(Func<HeadWaiter, bool> selector)
        {
            return _dining.HeadWaiters.Where(selector).ToArray();
        } 

        public void SendOrdersToKitchen(HeadWaiter headWaiter)
        {
            // Task
        }

        public void AssignMenus(Table table)
        {
            // Task
        }

        public void TakeOrders (Table table)
        {
            // Task
        }

        public void ServeBread(Table table)
        {
            // Task
        }

        public void ServeWater(Table table)
        {
            // Task
        }

        public void ServeMeal(Meal meal)
        {
            // Task
        }

        public void CleanTable()
        {
            // Task
        }
    }
}
