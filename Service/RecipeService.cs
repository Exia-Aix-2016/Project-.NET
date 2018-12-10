using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RecipeService
    {
        private Kitchen _kitchen;

        public RecipeService(Kitchen kitchen)
        {
            this._kitchen = kitchen;
        } 

        public Recipe GetRecipeFromOrder(Order order)
        {
            return order.Recipe;
        }

        public Recipe[] GetRecipe(Func<Recipe, bool> selector)
        {
            return _kitchen.Recipes.Where(selector).ToArray();
        }
    }
}
