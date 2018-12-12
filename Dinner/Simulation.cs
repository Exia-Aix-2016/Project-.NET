using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace Dinner
{
    class Simulation
    {
        private readonly DependencyInjector _injector;
        private ReceptionService _receptionService => _injector.Get<ReceptionService>();
        private TableService _tableService => _injector.Get<TableService>();
        private DinnerStaffService _staffService => _injector.Get<DinnerStaffService>();
        private CounterClientService _counterClientService => _injector.Get<CounterClientService>();
        private ClientService _clientService => _injector.Get<ClientService>();

        public Simulation(DependencyInjector injector)
        {
            _injector = injector;
        }

        public void Forward()
        {
            ClientReception();
            SendOrders();
            DistributeMenus();
            ChooseMeal();
            TakeOrders();
            Resupply();
            ServeMeal();
            EatMeal();
            CleanTables();
        }

        void ClientReception()
        {
            _receptionService.GenerateNewClients();

            foreach(var clients in _receptionService.GetNewClients())
            {
                Table[] tables = _tableService
                    .GetTables(x => !x.Reserved && x.NumberSlots >= clients.Length)
                    .OrderBy(x => x.NumberSlots)
                    .ToArray();
                if (tables.Length > 0)
                {
                    _staffService.AssignTable(clients, tables[0]);
                }
            }

        }

        void SendOrders()
        {
            HeadWaiter[] headWaiters = _staffService.GetHeadWaiters(x => x.Orders.Count > 0);
            foreach (var headWaiter in headWaiters)
            {
                _staffService.SendOrdersToKitchen(headWaiter);
            }
        }

        void DistributeMenus()
        {
            Table[] tables = _tableService.GetTables(x => x.Menus.Count == 0 && x.Items().Count > 0 && x.Items().All(y => y.Choice == null));

            foreach (Table table in tables)
            {
                if (_receptionService.IsMenuAvailable(table.Items().Count))
                {
                    _staffService.AssignMenus(table);
                    break;
                }
            }
        }

        void ChooseMeal()
        {
            Table[] tables = _tableService.GetTables(x => x.Menus.Count > 0 && x.Items().Count > 0 && x.Items().All(y => y.Choice == null && y.Order == null && y.TaskProcessor.QueueCount == 0));
            foreach(var table in tables)
            {
                _clientService.ChooseMeal(table);
            }
        }

        void TakeOrders()
        {
            Table[] tables = _tableService.GetTables(x => x.Items().Count > 0 && x.Items().All(y => y.Choice != null && y.Order == null));
            if (tables.Length > 0)
            {
                _staffService.TakeOrders(tables[0]);
            }
        }

        void Resupply()
        {
            Table[] tablesNoBread = _tableService.GetTables(x => x.Items().Count > 0 && x.Items().All(y => y.Order != null) && !x.BreadBasketFull);
            if(tablesNoBread.Length > 0)
            {
                _staffService.ServeBread(tablesNoBread[0]);
            }
            Table[] tablesNoWater = _tableService.GetTables(x => x.Items().Count > 0 && x.Items().All(y => y.Order != null) && !x.WaterBottleFull);
            if(tablesNoWater.Length > 0)
            {
                _staffService.ServeWater(tablesNoWater[0]);
            }
        }

        void ServeMeal()
        {
            Meal[] meals = _counterClientService.TakeMeals();
            foreach(var meal in meals)
            {
                _staffService.ServeMeal(meal);
            }
        }

        void EatMeal()
        {
            Client[] clients = _clientService.GetClients(x => x.Meal != null && !x.Finished && x.TaskProcessor.CurrentTask == null);
            foreach(var client in clients)
            {
                _clientService.Eat(client);
            }
        }

        void CleanTables()
        {
            Table[] tables = _tableService.GetTables(x => x.Items().Count > 0 && !x.WillBeClean && x.Items().All(y => y.Finished));
            if(tables.Length > 0)
            {
                _staffService.CleanTable(tables[0]);
            }
        }
    }
}
