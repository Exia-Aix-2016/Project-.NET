using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Service
{
    public class KitchenBootstrap : IBootstrap
    {
        public DependencyInjector Bootstrap()
        {
            
            DependencyInjector injector = new DependencyInjector();

            injector.Register<CounterServerService>(new CounterServerService(injector));
            injector.Register<Model.Counter>(new Model.Counter());
            injector.Register<MarmitonContext>(new MarmitonContext());

            MarmitonContext db = injector.Get<MarmitonContext>();

            var it = db.IngredientTypes.ToList();

            var i = db.Ingredients.ToList();

            /*db.Ingredients.Remove(i[0]);
            db.SaveChanges();*/

            var r = db.Recipes.ToList();

            return injector;
        }
    }
}
