using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ISimulation
    {
        void Start();
        void Stop();
        void Resume();
        void SlowDown();
        void SpeedUp();
        

    }
}
