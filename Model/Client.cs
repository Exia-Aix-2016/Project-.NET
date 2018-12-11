using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Client : ITaskProcessorContainer
    {
        private ITaskProcessor _TaskProcessor;

        public string Choice;
        public Order Order;
        public Meal Meal;
        public bool Finished = false;

        public Client()
        {
            _TaskProcessor = new TaskProcessor();
        }
        public ITaskProcessor TaskProcessor { get; }
    }
}
