using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class DinnerStaffService
    {
        public void AssignTable(Client[] clients, Table table)
        {
            // Task
        }

        public HeadWaiter[] GetHeadWaiters(Func<HeadWaiter, bool> selector)
        {
            return null;
        } 

        public void SendOrdersToKitchen(HeadWaiter headWaiter)
        {
            // Task
        }

        public void AssignMenus(Table table)
        {
            // Task
        }

        public void TakeOrders (Table table)
        {
            // Task
        }

        public void ServeBread(Table table)
        {
            // Task
        }

        public void ServeWater(Table table)
        {
            // Task
        }

        public void ServeMeal(Meal meal)
        {
            // Task
        }

        public void CleanTable()
        {
            // Task
        }
    }
}
