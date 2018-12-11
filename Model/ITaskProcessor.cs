using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ITaskProcessor
    {
        void AddTask(Task task);
        void AddTask(callback callback, int ticks);
        void RemoveTask(Task task);
        void Process();
        Task CurrentTask { get; }

        
    }
}
