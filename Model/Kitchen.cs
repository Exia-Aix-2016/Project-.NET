using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Kitchen
    {
        public readonly Fridge _fridge;
        public readonly CookingFires _cookingFires;
        public readonly Oven _oven;
        public readonly Recipe[] Recipes;
        public readonly Stock Stock;
        public readonly ToolStorage ToolStorage;
        public readonly DirtyStorage DirtyStorage;
        public readonly WashingMachine WashingMachine;

    }
}
