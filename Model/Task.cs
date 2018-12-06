using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public delegate T callback<T>(List<T> param);
    public class Task<T>
    {
        private List<T> param;
        private int tickRemaining;
        private callback<T> callback;

    }
}
