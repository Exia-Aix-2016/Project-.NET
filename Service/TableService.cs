using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TableService: Service
    {
        private DiningRoom _diningRoom => _injector.Get<DiningRoom>();

        public TableService(DependencyInjector injector): base(injector)
        {
        }

        public Table[] GetTables(Func<Table, bool> selector)
        {
            return _diningRoom.Tables.Where(selector).ToArray();
        }

        public Table getTableById(int tableId)
        {
            return _diningRoom.Tables.Where(table => table.TableID == tableId).First();
        }
    }
}
