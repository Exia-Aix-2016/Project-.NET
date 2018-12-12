using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;

namespace Kitchen
{
    class Simulation
    {
        private readonly DependencyInjector _injector;
        private CounterServerService _counterServerService => _injector.Get<CounterServerService>();
       // private KitchenStaffService _kitchenStaffService => _injector.Get<KitchenStaffService>();

        Simulation(DependencyInjector injector)
        {
            _injector = injector;
        }

        void Forward()
        {
            Cook();
        }

        void Cook()
        {
            Order[] orders = _counterServerService.GetOrders();
            if(orders.Length > 0)
            {
                /* if (_kitchenStaffService.GetRequirements(orders[0]))
                 {
                     //Meal meal = _kitchenStaffService.Cook(orders[0]);
                     //_counterServerService.PutMeals(meal);
                 }*/
                if (_counterServerService.GetRequirements(orders[0]))
                {
                    Meal meal = _counterServerService.Cook(orders[0]);
                    _counterServerService.PutMeals(meal);
                }

            }
            
        }
    }

}
