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

        public Recipe Choice;

        public Client()
        {
            _TaskProcessor = new TaskProcessor();
        }
        public ITaskProcessor TaskProcessor { get; }
    }
}
