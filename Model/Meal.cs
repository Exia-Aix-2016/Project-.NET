using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Meal
    {
        public readonly string Name;
        public Order Order;

        public Meal(string name)
        {
            Name = name;
        }

    }
}
