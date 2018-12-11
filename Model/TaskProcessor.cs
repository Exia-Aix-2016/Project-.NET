using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TaskProcessor : ITaskProcessor
    {
        private Queue<Task> _Tasks; //FIFO
        private bool _Occupied;

        public TaskProcessor()
        {
            _Tasks = new Queue<Task>();
        }

        public void AddTask(Task task)
        {
            _Tasks.Enqueue(task);
        }

        public void AddTask(Action callback, int ticks = 1)
        {
            _Tasks.Enqueue(new Task(callback, ticks));
        }

        public void RemoveTask(Task task)
        {
            _Tasks.ToList().Remove(task);
        }
        public void Process()
        {
            if (!_Tasks.Any()) return;
            _Occupied = true;
            Task task = CurrentTask;

            task.Exec();
            if(task.IsProcess) _Tasks.Dequeue();

            _Occupied = false;

        }

        public int Size => _Tasks.Count;

        /**
         * Return the number of total tick remaining. 
         */
        public int TotalTicks { get => _Tasks.Sum(task => task.TickRemaining);}

        public Task CurrentTask { get => _Tasks.Peek(); }

        public bool IsOccupied { get => _Occupied; }

        public int QueueLenght => _Tasks.Sum(x => x.TickRemaining);

        public int QueueCount => _Tasks.Count;
    }
}
