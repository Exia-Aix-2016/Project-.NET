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

        Simulation(DependencyInjector injector)
        {
            _injector = injector;
        }

        void Forward()
        {
            Client[] clients = _receptionService.GetNewClients();
            Table[] tables = _tableService
                .GetTables(x => x.Items().Count == 0 && x.NumberSlots >= clients.Length)
                .OrderBy(x => x.NumberSlots)
                .ToArray();
            if (tables.Length > 0)
            {
                _staffService.AssignTable(clients, tables[0]);
            }

        }
    }
}
