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
        private readonly DependencyInjector _injector;

        public DinnerStaffService(DependencyInjector injector)
        {
            _injector = injector;
            _dining = _injector.Get<DiningRoom>();
        }

        public void AssignTable(Client[] clients, Table table)
        {
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);

            headWaiter.TaskProcessor.AddTask(() => {
                _dining.Lobby.Remove(clients);
                table.AddItems(clients.ToList());
            });
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
            CounterClientService counterClientService = _injector.Get<CounterClientService>();
            headWaiter.TaskProcessor.AddTask(() =>
            {
                headWaiter.Orders.ForEach(order =>
                {
                    //TODO
                });
            });
        }

        public void AssignMenus(Table table)
        {
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);

            headWaiter.TaskProcessor.AddTask(() =>
            {
                var menus = new List<Menu>();
                for (int i = 0; i < table.Items().Count; i++)
                {
                    var menu = _dining.Menus.Last();
                    _dining.Menus.Remove(menu);
                    table.Menus.Add(menu);
                }
            });
 
        }

        public void TakeOrders (Table table)
        {
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);

            decimal ticks = table.Items().Count * 30;

            headWaiter.TaskProcessor.AddTask(() => {
                var orders = table.Items()
                    .Where(client => client.Choice != null)
                    .Select(client => new Order(client.Choice));
                headWaiter.Orders.AddRange(orders);
            }, (int) Math.Round(ticks)));
        }

        public void ServeBread(Table table)
        {
            _dining.ClerkWaiter.TaskProcessor.AddTask(() =>
            {
                table.BreadBasketFull = true;
            });
        }

        public void ServeWater(Table table)
        {
            _dining.ClerkWaiter.TaskProcessor.AddTask(() =>
            {
                table.WaterBottleFull = true;
            });
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
