using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Fridge : Container<Ingredient>
    {
        public Fridge(int numberSlots = 0) : base(numberSlots){}
    }
}
