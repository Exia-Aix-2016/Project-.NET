using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DinnerStaffService: Service
    {
        private DiningRoom _dining => _injector.Get<DiningRoom>();
        private CounterClientService _counterClientService => _injector.Get<CounterClientService>();
        private Configuration configuration => _injector.Get<Configuration>();

        public DinnerStaffService(DependencyInjector injector): base(injector)
        {
        }

        public void AssignTable(Client[] clients, Table table)
        {
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);
            table.Reserved = true;

            headWaiter.TaskProcessor.AddTask(() => {
                lock (_dining.Squares) lock (_dining.Lobby)
                {
                    headWaiter.StaffStatus = StaffStatus.ASSIGN_CLIENT_TO_TABLE;
                    _dining.Lobby.Remove(clients);
                    table.AddItems(clients.ToList());
                }
            }, configuration.TimeToAssignTable);
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
                .First();
        }

        public HeadWaiter[] GetHeadWaiters(Func<HeadWaiter, bool> selector)
        {
            return _dining.HeadWaiters.Where(selector).ToArray();
        } 

        public void SendOrdersToKitchen(HeadWaiter headWaiter)
        {
            headWaiter.TaskProcessor.AddTask(() =>
            {
                lock (_counterClientService) lock(_dining.Squares)
                {
                    headWaiter.StaffStatus = StaffStatus.SEND_ORDERS_TO_KITCHEN;
                    _counterClientService.PutOrders(headWaiter.Orders.ToArray());
                    headWaiter.Orders.Clear();
                }
            }, configuration.TimeToSendOrdersToKitchen);
        }

        public void AssignMenus(Table table)
        {
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);

            var menus = new List<Menu>();
            for (int i = 0; i < table.Items().Count; i++)
            {
                var menu = _dining.Menus.Last();
                _dining.Menus.Remove(menu);
            }

            headWaiter.TaskProcessor.AddTask(() =>
            {
                lock(_dining.Squares)
                {
                    headWaiter.StaffStatus = StaffStatus.ASSIGN_MENU;
                    menus.ForEach(x => table.Menus.Add(x));
                }
            }, configuration.TimeToAssignMenus);
 
        }

        public Table[] GetTablesOrderStatus(TableStatus tableOrderStatus)
        {
            return _dining.Tables.Where(table => table.TableOrderStatus == tableOrderStatus).ToArray();
        }

        public void TakeOrders(Table table)
        {
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);

            decimal ticks = table.Items().Count * configuration.TimeToOrder;

            headWaiter.TaskProcessor.AddTask(() => {
                lock (_dining.Squares)
                {
                    headWaiter.StaffStatus = StaffStatus.TAKE_ORDERS;
                    var orders = table.Items()
                        .Where(client => client.Choice != null)
                        .Select(client => new Order(client.Choice, table));
                    headWaiter.Orders.AddRange(orders);
                }
            }, (int) Math.Round(ticks));
        }

        public void ServeBread(Table table)
        {
            _dining.ClerkWaiter.TaskProcessor.AddTask(() =>
            {
                lock (_dining.ClerkWaiter) lock (_dining.Squares)
                {
                    _dining.ClerkWaiter.StaffStatus = StaffStatus.SERVE_BREAD;
                    table.BreadBasketFull = true;
                }
            }, configuration.TimeToServeBread);
        }

        public void ServeWater(Table table)
        {
            _dining.ClerkWaiter.TaskProcessor.AddTask(() =>
            {
                lock (_dining.ClerkWaiter) lock (_dining.Squares)
                {
                    _dining.ClerkWaiter.StaffStatus = StaffStatus.SERVE_WATER;
                    table.WaterBottleFull = true;
                }
            }, configuration.TimeToServeWater);
        }

        public void ServeMeal(Meal meal)
        {
            var waiter = GetWaiterByTable(meal.Order.Table);
            waiter.TaskProcessor.AddTask(() =>
            {
                lock (_dining.Squares)
                {
                    waiter.StaffStatus = StaffStatus.SERVE_MEAL;
                    Client client = meal.Order.Table.Items().Where(x => x.Choice == meal.Order.Recipe).First();
                    client.Meal = meal;

                }
            }, configuration.TimeToServeMeal);
        }

        public void CleanTable(Table table)
        {
            var waiter = GetWaiterByTable(table);
            waiter.TaskProcessor.AddTask(() =>
            {
                lock (_dining.Squares) lock (_dining.Menus)
                {
                waiter.StaffStatus = StaffStatus.CLEAN_TABLE;
                table.WaterBottleFull = false;
                table.BreadBasketFull = false;
                table.Menus.Clear();
                table.TableCloth = null;
                table.Clear();
                table.Reserved = false;
                }
            }, configuration.TimeToCleanTable);
        }
    }
}
