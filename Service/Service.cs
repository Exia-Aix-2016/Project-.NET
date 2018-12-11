using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class Service
    {
        protected readonly DependencyInjector _injector;
        public Service(DependencyInjector injector)
        {
            _injector = injector;
        }
    }
}
