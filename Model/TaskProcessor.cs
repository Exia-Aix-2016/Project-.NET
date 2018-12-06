using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class TaskProcessor
    {
        private Queue<Task> Tasks;
        private bool Occuped;


        public TaskProcessor()
        {
            Queue<Task> t = new Queue<Task>();
            createProcessor(ref t);
        }

        public TaskProcessor(ref Queue<Task> tasks) => createProcessor(ref tasks);
        private void createProcessor(ref Queue<Task> tasks) {
            Tasks = tasks;
            Occuped = false;
        }

        public void AddTask(Task task)
        {
            Tasks.Enqueue(task);
        }
        public void Process()
        {
            Occuped = false;
            Tasks.Dequeue().exec();
            Occuped = true;
        }

        public Task GetCurrentTask { get => Tasks.ElementAt(Tasks.Count - 1); }
   
    }
}
