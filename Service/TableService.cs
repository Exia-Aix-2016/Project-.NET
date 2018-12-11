using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TableService
    {
        private readonly DependencyInjector _injector;
        private DiningRoom _diningRoom => _injector.Get<DiningRoom>();

        public TableService(DependencyInjector injector)
        {
            _injector = injector;
        }

        public Table[] GetTables(Func<Table, bool> selector)
        {
            return _diningRoom.Tables.Where(selector).ToArray();
        }

    }
}
