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
        public readonly Recipe Recipe;
        public readonly Table Table;

        public Order(Recipe recipe, Table table)
        {
            Recipe = recipe;
            Table = table;
        }
    }
}
