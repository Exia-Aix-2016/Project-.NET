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
        private DiningRoom _diningRoom;

        public TableService(DiningRoom diningRoom)
        {
            this._diningRoom = diningRoom;
        }

        public Table[] GetTables(Func<Table, bool> selector)
        {
            return _diningRoom.Tables.Where(selector).ToArray();
        }

    }
}
