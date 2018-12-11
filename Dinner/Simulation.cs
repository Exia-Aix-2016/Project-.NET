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
            TakeOrders();
            Resupply();
            ServeMeal();
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
            Table[] tables = _tableService.GetTables(x => x.Menus.Count == 0);
            foreach(var table in tables)
            {
                if (_receptionService.IsMenuAvailable(table.Items().Count))
                {
                    _staffService.AssignMenus(table);
                    _clientService.ChooseMeal(table);
                    break;
                }
            }
        }

        void TakeOrders()
        {
            Table[] tables = _tableService.GetTables(x => x.Items().All(y => y.Choice != null && y.Order == null));
            if (tables.Length > 0)
            {
                _staffService.TakeOrders(tables[0]);
            }
        }

        void Resupply()
        {
            Table[] tablesNoBread = _tableService.GetTables(x => x.Items().All(y => y.Order != null) && !x.BreadBasketFull);
            if(tablesNoBread.Length > 0)
            {
                _staffService.ServeBread(tablesNoBread[0]);
            }
            Table[] tablesNoWater = _tableService.GetTables(x => x.Items().All(y => y.Order != null) && !x.WaterBottleFull);
            if(tablesNoWater.Length > 0)
            {
                _staffService.ServeBread(tablesNoWater[0]);
            }
        }

        void ServeMeal()
        {
            Meal[] meals = _counterClientService.TakeMeals();
            foreach(var meal in meals)
            {
                _staffService.ServeMeal(meal);
                Table table = _tableService.GetTables(x => x.Items().Any(y => y.Order == meal.Order)).Single();
                _clientService.Eat(table.Items().Where(x => x.Order == meal.Order).Single());
            }
        }

        void CleanTables()
        {
            Table[] tables = _tableService.GetTables(x => x.Items().All(y => y.Finished));
            if(tables.Length > 0)
            {
                _staffService.CleanTable(tables[0]);
            }
        }
    }
}
