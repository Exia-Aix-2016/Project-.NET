using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Recipe
    {
        public readonly Dictionary<Ingredient, int> Ingredients;
        public readonly Dictionary<ToolsType, int> ToolsNeeds;
        public readonly int _CookingTimeRemaining;
        public readonly string Name;
        

        public Recipe(string name, int cookingTimeRemaining, Dictionary<Ingredient, int> ingredient, Dictionary<ToolsType, int> toolsNeeds)
        {
            Name = name;
            _CookingTimeRemaining = cookingTimeRemaining;
            Ingredients = ingredient;
            ToolsNeeds = toolsNeeds;

        }



        public int CookingTimeRemaining { get; }


    }
}
