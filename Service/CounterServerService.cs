using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CounterServerService
    {
        private DependencyInjector _injector;
        private Counter _counter => _injector.Get<Counter>();
        private MarmitonContext _marmitonContext => _injector.Get<MarmitonContext>();

        public CounterServerService(DependencyInjector dependency)
        {
            KitchenConnection.Instance.OnreceiveEvent += new KitchenConnection.ReceiveDel(Receive);
            KitchenConnection.Instance.Start();
            _injector = dependency;
        }
        public void Receive(byte[] data)
        {
           MessageSocket message =  Model.Counter.Deserialize<Model.MessageSocket>(data);

            if (message.HasOrders)
            {
                _counter.AddOrders(message.Orders);

                /*TEMPORAIRE*/
                foreach(var order in message.Orders)
                {
                    Meal meal = Cook(order);
                    PutMeals(meal);
                }
                /*TEMPORAIRE*/
                Console.WriteLine("BLABLA");
            }

            if (message.HasOrders) _counter.AddOrders(message.Orders);
        }
        public Order[] GetOrders()
        {
            return _counter.TakeOrders();
        }

        public void PutMeals(Meal meal)
        {
            Meal[] meals = new Meal[1];
            meals[0] = meal;
            MessageSocket message = new MessageSocket(meals);
            KitchenConnection.Instance.Send(message);
        }

        /*public bool GetRequirements(Order order)
        {
            string nameRecipe = _marmitonContext.Recipes.Where(x => x.Name == order.Recipe).Single().Name;            
            foreach(RecipeIngredient recipeIngredient  in _marmitonContext.Recipes.Where(x => x.Name == nameRecipe).Single().Ingredients)
            {
                if(_marmitonContext.Ingredients.Where(x => x.Type.Name == recipeIngredient.IngredientTypeName).Count() < recipeIngredient.Quantity)
                {
                    return false;
                }
            }
            return true;
        }*/

        public Meal Cook(Order order)
        {
            Recipe recipe = _marmitonContext.Recipes.Where(x => x.Name == order.Recipe).Single();

            foreach (RecipeIngredient ingredient in recipe.Ingredients)
            {
                foreach(var i in _marmitonContext.IngredientTypes
                            .Where(x => x.Name == ingredient.IngredientType.Name)
                            .SelectMany(x => x.Ingredients)
                            .Take(ingredient.Quantity))
                {
                    _marmitonContext.Ingredients.Remove(i);
                }
                _marmitonContext.SaveChanges();
            }
            return new Meal(recipe.Name, order);
        }
    }
}
