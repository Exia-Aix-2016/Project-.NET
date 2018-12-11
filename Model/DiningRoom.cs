using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DiningRoom
    {
        private static readonly object _locker = new object();
        public readonly List<Square> Squares = new List<Square>();
        public readonly List<Client[]> Lobby = new List<Client[]>();
        public readonly List<Menu> Menus = new List<Menu>();
        public ClerkWaiter ClerkWaiter;
        public Counter Counter;

        public DiningRoom()
        {
            Counter = new Counter();
        }

        public HeadWaiter[] HeadWaiters
        {
            get => Squares.Select(x => x.HeadWaiter).ToArray();
        }



        public Client[] Clients
        {

            get
            {
                lock (_locker)
                {
                    return Squares
                     .SelectMany(x => x.Items())
                     .SelectMany(x => x.Items())
                     .SelectMany(x => x.Items())
                     .ToArray();
                }
            }

        }

        public Table[] Tables
        {
            get => Squares
                .SelectMany(x => x.Items())
                .SelectMany(x => x.Items())
                .ToArray();
        }

        public Waiter[] Waiters => Squares
            .SelectMany(x => x.Waiters)
            .ToArray();

        public ITaskProcessor[] TaskProcessors
        {
            get {
                List<ITaskProcessor> taskProcessors = new List<ITaskProcessor>();
                taskProcessors.AddRange(HeadWaiters.Select(x => x.TaskProcessor));
                taskProcessors.AddRange(Waiters.Select(x => x.TaskProcessor));
                taskProcessors.AddRange(Clients.Select(x => x.TaskProcessor));
                return taskProcessors.ToArray();
            }
        }
    }
}
