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
        public ITaskProcessor TaskProcessor { get => _TaskProcessor; }
    }
}
