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
        public readonly int TableId;

        public Order(string recipeName, int tableId)
        {
            Recipe = recipeName;
            TableId = tableId;
        }
    }
}
