using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Clerk : ITaskProcessorContainer
    {
        private ITaskProcessor _TaskProcessor;

        public Clerk()
        {
            _TaskProcessor = new TaskProcessor();
        }
        public ITaskProcessor TaskProcessor { get; }
    }
}
