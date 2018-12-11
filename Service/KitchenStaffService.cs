using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class KitchenStaffService
    {
        private Kitchen _kitchen;
        private MarmitonContext _marmitonContext;
        private readonly DependencyInjector _injector;

        public KitchenStaffService(DependencyInjector injector)
        {
            _injector = injector;
            _kitchen = _injector.Get<Kitchen>();
            _marmitonContext = _injector.Get<MarmitonContext>();
        }

        public void AssignRecipe(Model.Recipe recipe)
        {
            // Task
        }

        public bool GetRequirements(Order order)
        {
            foreach (KeyValuePair<Model.Ingredient, int> ingredientQuantity in order.Recipe.Ingredients)
            {
                if(_marmitonContext.Ingredients.Where(x => x.Type.Name == ingredientQuantity.Key.Name).Count() >= ingredientQuantity.Value)
                {
                    return false;
                }
            }
            return true;
        }

        public Meal Cook(Order order)
        {
            foreach(Model.Ingredient ingredient in order.GetIngredients())
            {
                _marmitonContext.Ingredients.Remove(_marmitonContext.Ingredients.Where(x => x.Type.Name == ingredient.Name).Single());
            }
            return new Meal(order.Recipe.Name); 
        }

        public void StartCooking(Model.Recipe recipe)
        {
            // Task
        }

        public void Serve(Model.Recipe recipe)
        {
            // Task
        }

        public void PutRequirementInSink(Model.Recipe recipe)
        {
            // Task
        }

        public void Bake(Model.Recipe recipe)
        {
            // Task
        }

        public void FreeMashingMachine()
        {
            // Task
        }

        public void FillWashingMachine()
        {
            // Task
        }

        public void StartWashingMachine()
        {
            // Task
        }

        public void Wash()
        {
            // Task
        }

    }
}
