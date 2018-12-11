using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Menu
    {
        public readonly List<string> Recipe;


        public Menu(List<string> recipe)
        {
            Recipe = recipe;
        }
    }
}
