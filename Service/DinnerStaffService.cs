using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);

            headWaiter.TaskProcessor.AddTask(new Task(x => {
                List<Client> clientsList = clients.ToList();
                clientsList.ForEach(client => _dining.Lobby.Remove(client));
                table.AddItems(ref clientsList);
            }));
        }

        public HeadWaiter GetHeadWaiterByTable(Table table)
        {
            return _dining.Squares
                .Where(x => x.Items().Where(y => y.Items().Contains(table)).Any())
                .Select(x => x.HeadWaiter)
                .Single();
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
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);

            headWaiter.TaskProcessor.AddTask(new Task(x =>
            {
                var menus = new List<Menu>();
                for (int i = 0; i < table.Items().Count; i++)
                {
                    var menu = _dining.Menus.Last();
                    _dining.Menus.Remove(menu);
                    table.Menus.Add(menu);
                }

            }));
 
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
