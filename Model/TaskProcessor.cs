using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TaskProcessor
    {
        private Queue<Task> _Tasks;
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
        public void Process()
        {
            _Occupied = false;
            _Tasks.Dequeue().exec();
            _Occupied = true;
        }

        public int TotalTicks { get => _Tasks.Sum(task => task.TickRemaining);}

        public Task GetCurrentTask { get => _Tasks.ElementAt(_Tasks.Count - 1); }

        public bool IsOccupied { get => _Occupied; }
   
    }
}
