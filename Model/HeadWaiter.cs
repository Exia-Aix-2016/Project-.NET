using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HeadWaiter : ITaskProcessorContainer
    {
        public StaffStatus StaffStatus;
        public ITaskProcessor TaskProcessor { get; } = new TaskProcessor();

        public readonly List<Order> Orders = new List<Order>();
        

    }
}
