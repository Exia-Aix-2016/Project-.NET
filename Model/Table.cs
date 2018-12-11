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
        public Cloth TableCloth;

        public Table(int tableID, int numberchairs) : base(numberchairs)
        {
            TableID = tableID;
        }

        public TableStatus TableOrderStatus
        {
            get
            {
                if (Storage.TrueForAll(client => client.Choice != null))
                {
                    return TableStatus.CHOOSEN;
                }
                else
                {
                    return TableStatus.NOT_CHOOSEN;
                }
            }
        }
    }
    
}
