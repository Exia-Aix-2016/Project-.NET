using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Square : Container<Rank>
    {

        public readonly int SquareID;
        public HeadWaiter HeadWaiter;
        public readonly List<Waiter> Waiters = new List<Waiter>();

        public Square(int squareID, int numberRanks) : base(numberRanks)
        {
            SquareID = squareID;
        }


    }
}
