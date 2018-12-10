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

        public DiningRoom(int numberSquares) { }

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
    }
}
