using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Stock
    {
        public readonly Ingredient[] Ingredients;

        public Stock(Ingredient[] ingredients)
        {
            this.Ingredients = ingredients;
        }
    }
}
