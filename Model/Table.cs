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

        public Table(int tableID, int numberchairs) : base(numberchairs)
        {
            TableID = tableID;
        }



    }
}
