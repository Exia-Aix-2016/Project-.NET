using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ICleaningDevice<T>
    {
        List<T> Retrieve();
        void StartMachine();
        bool Available { get; }
    }
}
