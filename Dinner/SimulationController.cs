using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Model;
using Task = System.Threading.Tasks.Task;

namespace Dinner
{
    public class SimulationController : ISimulation
    {
        private readonly DependencyInjector _injector;
        private DiningRoom diningRoom => _injector.Get<DiningRoom>();
        private readonly Simulation _simulation;
        private bool _running = false;
        public int Speed { get; private set; } = 1;
        private Task task;
        private int PoolQueueLength = 0;
        private ManualResetEvent @event = new ManualResetEvent(false);
        private double MillisToWait => 1 / Speed * 1000;
        private readonly Action<DiningRoom> renderCallback;
        public int Ticks { get; private set; } = 0;

        public SimulationController(Action<DiningRoom> renderCallback)
        {
            IBootstrap b = new DinnerBootstrap();
            _injector = b.Bootstrap();
            _simulation = new Simulation(_injector);
            this.renderCallback = renderCallback;
        }

        private void Run()
        {
            while (_running)
            {
                DateTime startTime = DateTime.Now;
                PoolQueueLength = 0;
                @event.Reset();

                if(diningRoom.TaskProcessors.Length > 0)
                {
                    foreach (var taskProcessor in diningRoom.TaskProcessors)
                    {
                        if (taskProcessor != null)
                        {
                            PoolQueueLength++;
                            ThreadPool.QueueUserWorkItem(x =>
                            {
                                taskProcessor.Process();
                                PoolQueueLength--;
                                if (PoolQueueLength == 0)
                                {
                                    @event.Set();
                                }
                            });
                        }
                    }
                    @event.WaitOne();
                }

                _simulation.Forward();


                TimeSpan interval = DateTime.Now - startTime;
                int millisToSleep = (int)Math.Round(MillisToWait - interval.Milliseconds);
                if (millisToSleep > 0)
                {
                    Thread.Sleep(millisToSleep);
                }

                Ticks++;

                new Task(() => renderCallback(diningRoom)).Start();
            }
        }


        public void SlowDown()
        {
            if (Speed >= 2)
            {
                Speed--;
            }
        }

        public void SpeedUp()
        {
            if (Speed < 7)
            {
                Speed++;
            }
        }

        public void Start()
        {
            if(task == null)
            {
                _running = true;
                task = new Task(Run);
                task.Start();
            } else
            {
                Console.WriteLine("The simulation is already running");
            }
        }

        public void Stop()
        {
            if (task != null)
            {
                _running = false;
                task.Wait();
                task = null;
            }else
            {
                Console.WriteLine("The simulation is already stopped");
            }
        }
    }
}
