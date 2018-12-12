using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    public class SimulationController : Model.ISimulation
    {

        private readonly DependencyInjector _injector;
        private readonly Simulation _simulation;

        public SimulationController()
        {
            IBootstrap b = new KitchenBootstrap();
            _injector = b.Bootstrap();
            _simulation = new Simulation(_injector);
        }
        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void SlowDown()
        {
            throw new NotImplementedException();
        }

        public void SpeedUp()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
