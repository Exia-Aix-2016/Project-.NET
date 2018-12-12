﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class KitchenBootstrap : IBootstrap
    {
        public DependencyInjector Bootstrap()
        {
            DependencyInjector injector = new DependencyInjector();


            injector.Register<Model.Counter>(new Model.Counter());
            injector.Register<CounterServerService>(new CounterServerService(injector));


            return injector;
        }
    }
}
