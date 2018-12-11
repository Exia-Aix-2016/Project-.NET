using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ITaskProcessor
    {
        int QueueLenght { get; }
        int QueueCount { get; }
        void AddTask(Task task);
        void AddTask(Action callback, int ticks = 1);
        void AddTask(Action callback, int ticks = 1, string name = "");
        void RemoveTask(Task task);
        void Process();
        Task CurrentTask { get; }
    }
}
