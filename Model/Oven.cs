using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Oven : ICookDevice, ITaskProcessorContainer
    {

        private Recipe _Recipe;
        private Meal _Meal;
        private ITaskProcessor _TaskProcessor;

        public Oven()
        {
            _TaskProcessor = new TaskProcessor();
            _Recipe = null;
            _Meal = null;
        }

        public void AddRecipe(ref Recipe recipe)
        {
            if (recipe == null) throw new ArgumentNullException("Oven : recipe is null");

            if (_Recipe == null)
            {
                _Recipe = recipe;

                _TaskProcessor.AddTask(new Task((Void) => {

                    _Meal = new Meal(_Recipe.Name);
                    _Recipe = null;

                }));
            }
        }
        public bool Available { get => (_Recipe == null && _Meal == null) ? true : false; }

        public ITaskProcessor TaskProcessor { get; }

        public Meal TakeMeal
        {
            get
            {
                Meal m = _Meal;
                _Meal = null;
                return m;
            }
        }

        public bool IsCookFinished { get => (_Meal != null) ? true : false; }
    }
}
