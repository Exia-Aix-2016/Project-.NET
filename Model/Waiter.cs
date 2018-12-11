using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    public class Waiter : ITaskProcessorContainer
    {
        public ITaskProcessor TaskProcessor { get; } = new TaskProcessor();
    }
}
