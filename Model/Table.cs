using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Table : Container<Client>
    {
        public readonly int TableID;
        public readonly IList<Menu> Menus = new List<Menu>();
        public bool BreadBasketFull = false;
        public bool WaterBottleFull = false;
        public bool Reserved = false;
        public bool WillBeClean = false;
        private TableStatus _tableStatus;

        public Table(int tableID, int numberchairs) : base(numberchairs)
        {
            TableID = tableID;
            _tableStatus = TableStatus.NOT_ASSIGNED;
        }

        public TableStatus TableOrderStatus
        {
            get
            {
                if (Items().TrueForAll(client => client.Finished == false)) return TableStatus.FINISH;

                if (Items().TrueForAll(client => client.Finished == false && client.Meal != null)) return TableStatus.EATING;

                if (Items().TrueForAll(client => client.Finished == false && client.Meal == null)) return TableStatus.CHOOSEN;

                return TableStatus.NOT_ASSIGNED;
            }
        }
        

    }
}
    

