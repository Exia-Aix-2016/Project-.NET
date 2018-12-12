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
            _injector = dependency;
        }
        public void Receive(byte[] data)
        {
           MessageSocket message =  Model.Counter.Deserialize<Model.MessageSocket>(data);

            if (message.HasOrders) _counter.AddOrders(message.Orders);

            /*TEMPORAIRE*/
            List<Meal> meals = new List<Meal>();          
            message.Orders.ToList().ForEach(order => meals.Add(new Meal(order.Recipe, order)));
            PutMeals(meals.First());
            /*TEMPORAIRE*/

            Console.WriteLine("TESTKITCHEN");
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

        public bool GetRequirements(Order order)
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
        }

        public Meal Cook(Order order)
        {
            string nameRecipe = _marmitonContext.Recipes.Where(x => x.Name == order.Recipe).Single().Name;

            foreach (RecipeIngredient ingredient in _marmitonContext.Recipes.Where(x => x.Name == nameRecipe).Single().Ingredients)
            {
                _marmitonContext.Ingredients.Remove(_marmitonContext.Ingredients.Where(x => x.Type.Name == ingredient.IngredientTypeName).Single());
            }
            return new Meal(nameRecipe, order);
        }
    }
}
