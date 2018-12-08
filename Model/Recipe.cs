using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Recipe
    {
        private Dictionary<Ingredient, int> _Ingredients;
        private List<Tool> _ToolsNeeds;
        private int _CookingTimeRemaining;
        public readonly string Name;
        

        Recipe(string name, int cookingTimeRemaining, Dictionary<Ingredient, int> ingredient)
        {
            Name = name;
            _CookingTimeRemaining = cookingTimeRemaining;
            _Ingredients = ingredient;

        }



        public int CookingTimeRemaining { get; }


    }
}
