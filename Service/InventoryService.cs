using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Service
{
    public class InventoryService
    {
        /*private Kitchen _kitchen;

        public InventoryService(DependencyInjector dependencyInjector)
        {
            _kitchen = dependencyInjector.Get<Kitchen>();
        }

        public bool IsRequirementAvailable(Recipe recipe)
        {
            bool Tools = false;
            List<bool> ToolsCart = new List<bool>();
            bool Ingredients = false;
            List<bool> IngredientsCart = new List<bool>();

            foreach (KeyValuePair<ToolsType, int> toolNeed in recipe.ToolsNeeds)
            {
                if (_kitchen.ToolStorage.Items().Where(tool => toolNeed.Key == tool.ToolsType).Count() >= toolNeed.Value)
                {
                    ToolsCart.Add(true);
                }
                else
                {
                    ToolsCart.Add(false);
                }
            }
            if (!ToolsCart.Contains(false))
                Tools = true;

            foreach (KeyValuePair<Ingredient, int> ingredientNeed in recipe.Ingredients)
            {
                if (_kitchen.Stock.Items().Where(ingredient => ingredientNeed.Key.Name == ingredient.Name).Count() >= ingredientNeed.Value)
                {
                    IngredientsCart.Add(true);
                }
                else
                {
                    IngredientsCart.Add(false);
                }
            }
            if (!IngredientsCart.Contains(false))
                Tools = true;

            if (Tools && Ingredients)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}
