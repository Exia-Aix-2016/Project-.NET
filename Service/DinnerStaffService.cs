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
        private CounterClientService _counterClientService => _injector.Get<CounterClientService>();

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

        public Waiter GetWaiterByTable(Table table)
        {
            return _dining.Squares
                .Where(x => x.Items().Where(y => y.Items().Contains(table)).Any())
                .SelectMany(x => x.Waiters)
                .OrderBy(x => x.TaskProcessor.QueueLenght)
                .Single();
        }

        public HeadWaiter[] GetHeadWaiters(Func<HeadWaiter, bool> selector)
        {
            return _dining.HeadWaiters.Where(selector).ToArray();
        } 

        public void SendOrdersToKitchen(HeadWaiter headWaiter)
        {
            headWaiter.TaskProcessor.AddTask(() =>
            {
                _counterClientService.PutOrders(headWaiter.Orders.ToArray());
                headWaiter.Orders.Clear();
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

        public void TakeOrders(Table table)
        {
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);

            decimal ticks = table.Items().Count * 30;

            headWaiter.TaskProcessor.AddTask(() => {
                var orders = table.Items()
                    .Where(client => client.Choice != null)
                    .Select(client => new Order(client.Choice, table));
                headWaiter.Orders.AddRange(orders);
            }, (int) Math.Round(ticks));
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
            var waiter = GetWaiterByTable(meal.Order.Table);
            waiter.TaskProcessor.AddTask(() =>
            {
                Client client = meal.Order.Table.Items().Where(x => x.Choice == meal.Order.Recipe).Single();
                client.Meal = meal;
            }, 5);
        }

        public void CleanTable(Table table)
        {
            var waiter = GetWaiterByTable(table);
            waiter.TaskProcessor.AddTask(() =>
            {
                table.WaterBottleFull = false;
                table.BreadBasketFull = false;
                table.Menus.Clear();
                table.TableCloth = null;
                table.Clear();
            });
        }
    }
}
