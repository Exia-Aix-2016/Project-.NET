using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Recipe
    {
        private Dictionary<Ingredient, int> ingredients;
        private List<Tool> tools;
        private int cookingTimeRemaining;
        private int bakingTimeRemaining;


        public Recipe(int cookingTimeRemaining, int bakingTimeRemaining)
        {
            createRecipe(cookingTimeRemaining, bakingTimeRemaining, new Dictionary<Ingredient, int>());
        }
        public Recipe(int cookingTimeRemaining, int bakingTimeRemaining, ref Dictionary<Ingredient, int> ingredients)
        {
            createRecipe(cookingTimeRemaining, bakingTimeRemaining, ingredients);
        }

        private void createRecipe(int cookingTimeRemaining, int bakingTimeRemaining, Dictionary<Ingredient, int> ingredients)
        {
            BakingTimeRemaining = bakingTimeRemaining;
            CookingTimeRemaining = cookingTimeRemaining;
            Ingredients = ingredients;
        }

        public int BakingTimeRemaining { get => bakingTimeRemaining; set => bakingTimeRemaining = (value > 0) ? value : 1; }

        public int CookingTimeRemaining { get => cookingTimeRemaining; set => cookingTimeRemaining = (value > 0) ? value : 1; }

        public Dictionary<Ingredient, int> Ingredients { get => ingredients; set => ingredients = value; }

    }
}
