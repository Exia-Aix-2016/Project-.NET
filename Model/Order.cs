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

        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach(KeyValuePair<Ingredient, int> keyValuePair in Recipe.Ingredients)
            {
                for(int i=0; i < keyValuePair.Value; i++)
                {
                    ingredients.Add(keyValuePair.Key);
                }
            }
            return ingredients;
        }
    }
}
