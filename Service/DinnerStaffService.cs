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
        private TableService _tableService => _injector.Get<TableService>();
        private Configuration configuration => _injector.Get<Configuration>();

        public DinnerStaffService(DependencyInjector injector): base(injector)
        {
        }

        public void AssignTable(Client[] clients, Table table)
        {
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);
            table.Reserved = true;
            _dining.Lobby.Remove(clients);

            headWaiter.TaskProcessor.AddTask(() => {
                lock (_dining.Squares) lock (_dining.Lobby)
                {
                    table.AddItems(clients.ToList());
                }
            }, configuration.TimeToAssignTable, "ASSIGN_CLIENT_TO_TABLE");
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
                lock (_counterClientService) lock (_dining.Squares)
                    {
                        _counterClientService.PutOrders(headWaiter.Orders.ToArray());
                        headWaiter.Orders.Clear();
                    }
            }, configuration.TimeToSendOrdersToKitchen, "SEND_ORDERS_TO_KITCHEN", true);
        }

        public void AssignMenus(Table table)
        {
            HeadWaiter headWaiter = GetHeadWaiterByTable(table);

            if (headWaiter.TaskProcessor.GetTasks("ASSIGN_MENU").Length == 0)
            {
                var menus = new List<Menu>();
                for (int i = 0; i < table.Items().Count; i++)
                {
                    var menu = _dining.Menus.Last();
                    _dining.Menus.Remove(menu);
                    menus.Add(menu);
                }

                headWaiter.TaskProcessor.AddTask(() =>
                {
                    lock (_dining.Squares)
                    {
                        menus.ForEach(x => table.Menus.Add(x));
                    }
                }, configuration.TimeToAssignMenus, "ASSIGN_MENU");
            }
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
                    var orders = table.Items()
                        .Where(client => client.Choice != null)
                        .Select(client => {
                            var order = new Order(client.Choice, table.TableID);
                            client.Order = order;
                            return order;
                        });
                    headWaiter.Orders.AddRange(orders);
                    _dining.Menus.AddRange(table.Menus);
                    table.Menus.Clear();
                }
            }, (int)Math.Round(ticks), "TAKE_ORDERS", true);
        }

        public void ServeBread(Table table)
        {
            _dining.ClerkWaiter.TaskProcessor.AddTask(() =>
            {
                lock (_dining.ClerkWaiter) lock (_dining.Squares)
                {
                    table.BreadBasketFull = true;
                }
            }, configuration.TimeToServeBread, "SERVE_BREAD", true);
        }

        public void ServeWater(Table table)
        {
            _dining.ClerkWaiter.TaskProcessor.AddTask(() =>
            {
                lock (_dining.ClerkWaiter) lock (_dining.Squares)
                {
                    table.WaterBottleFull = true;
                }
            }, configuration.TimeToServeWater, "SERVE_WATER", true);
        }

        public void ServeMeal(Meal meal)
        {
            var waiter = GetWaiterByTable(_tableService.getTableById(meal.Order.TableId));
            waiter.TaskProcessor.AddTask(() =>
            {
                lock (_dining.Squares)
                {
                    Client client = _tableService.getTableById(meal.Order.TableId).Items().Where(x => x.Choice == meal.Order.Recipe).First();
                    client.Meal = meal;

                }
            }, configuration.TimeToServeMeal, "SERVE_MEAL");
        }

        public void CleanTable(Table table)
        {
            var waiter = GetWaiterByTable(table);
            waiter.TaskProcessor.AddTask(() =>
            {
                lock (_dining.Squares) lock (_dining.Menus)
                {
                table.WaterBottleFull = false;
                table.BreadBasketFull = false;
                table.Menus.Clear();
                table.Clear();
                table.Reserved = false;
                }
            }, configuration.TimeToCleanTable, "CLEAN_TABLE");
        }
    }
}
