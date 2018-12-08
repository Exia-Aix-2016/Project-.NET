using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public readonly List<Recipe> _Recipes;

        public Order(ref List<Recipe> recipes) => _Recipes = recipes;

    }
}
