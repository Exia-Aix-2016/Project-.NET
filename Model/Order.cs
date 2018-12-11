using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Order
    {
        public readonly string Recipe;
        public readonly Table Table;

        public Order(string recipeName, Table table)
        {
            Recipe = recipeName;
            Table = table;
        }
    }
}
