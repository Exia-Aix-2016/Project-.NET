using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Model;
using Task = System.Threading.Tasks.Task;
using System.Windows.Threading;

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
        private double MillisToWait => 1 / Speed * 1000;
        private readonly Action<DiningRoom> renderCallback;
        private Thread mainThread;
        public int Ticks { get; private set; } = 0;
        private readonly object PoolQueueLengthLock = new object();

        public SimulationController(Action<DiningRoom> renderCallback, Thread thread)
        {
            mainThread = thread;
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
                CountdownEvent countdown = new CountdownEvent(diningRoom.TaskProcessors.Length);

                if(diningRoom.TaskProcessors.Length > 0)
                {
                    foreach (var taskProcessor in diningRoom.TaskProcessors)
                    {
                        ThreadPool.QueueUserWorkItem(x =>
                        {
                            taskProcessor?.Process();
                            countdown.Signal();
                        });
                    }
                    countdown.Wait();
                }

                _simulation.Forward();

                TimeSpan interval = DateTime.Now - startTime;
                int millisToSleep = (int)Math.Round(MillisToWait - interval.Milliseconds);
                if (millisToSleep > 0)
                {
                    Thread.Sleep(millisToSleep);
                }

                Ticks++;

                Dispatcher.FromThread(mainThread).Invoke(() =>
                {
                    renderCallback(diningRoom);
                });
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
