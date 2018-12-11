using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DiningRoom
    {
        public readonly IList<Square> Squares = new List<Square>();
        public readonly IList<Client> Lobby = new List<Client>();
        public readonly IList<Menu> Menus = new List<Menu>();
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
            get => Squares
                .SelectMany(x => x.Items())
                .SelectMany(x => x.Items())
                .SelectMany(x => x.Items())
                .ToArray();
        }

        public Table[] Tables
        {
            get =>  Squares
                .SelectMany(x => x.Items())
                .SelectMany(x => x.Items())
                .ToArray();
        }
    }
}
