using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class DinnerBootstrap : IBootstrap
    {
        public DependencyInjector Bootstrap()
        {
            DependencyInjector injector = new DependencyInjector();

            DiningRoom diningRoom = new DiningRoom();

            injector.Register<DiningRoom>(diningRoom);
            injector.Register<ClientService>(new ClientService(injector));
            injector.Register<ClientService>(new ClientService(injector));
            injector.Register<ClientService>(new TableService(injector));
            injector.Register<ClientService>(new DinnerStaffService(injector));

            return injector;
        }
    }
}
