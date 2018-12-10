using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Counter
    {
        private List<Order> _Orders;
        private List<Meal> _Meals;

        public Counter()
        {
            _Orders = new List<Order>();
            _Meals = new List<Meal>();
        }

        public void AddOrder(Order order)
        {
            _Orders.Add(order);
        }
        public void AddOrders(Order[] orders)
        {
            _Orders.AddRange(orders);
        }

        

    }
}
