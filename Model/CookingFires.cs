using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CookingFires : TaskProcessor
    {
        private Recipe _Recipe;

        public CookingFires()
        {
            _Recipe = null;
        }

        public void AddRecipe(ref Recipe recipe)
        {
            if (recipe == null) throw new ArgumentNullException("CookingFires : recipe is null");

            if (_Recipe == null)
            {
                _Recipe = recipe;

                AddTask(new Task(null, recipe.CookingTimeRemaining, (Void) =>{}));
            }
        }

        public bool Available { get => (_Recipe == null) ? true : false; }

       



    }
}
