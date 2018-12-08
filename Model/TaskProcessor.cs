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
            Queue<Task> t = new Queue<Task>();
            CreateProcessor(ref t);
        }
        public TaskProcessor(ref Queue<Task> tasks) => CreateProcessor(ref tasks);

        private void CreateProcessor(ref Queue<Task> tasks) {
            _Tasks = tasks;
            _Occupied = false;

        }

        public void AddTask(Task task)
        {
            _Tasks.Enqueue(task);
        }
        public void RemoveTask(Task task)
        {
            _Tasks.ToList().Remove(task);
        }
        public void Process()
        {
            _Occupied = true;
            Task task = _Tasks.Peek();
            task.exec();
            if (task.TickRemaining == 0) _Tasks.Dequeue(); //Quand la task à fini de process on l'enlève de la queue 
            _Occupied = false;

        }

        /**
         * Return the number of total tick remaining. 
         */
        public int TotalTicks { get => _Tasks.Sum(task => task.TickRemaining);}

        public Task GetCurrentTask { get => _Tasks.Peek(); }

        public bool IsOccupied { get => _Occupied; }
   
    }
}
