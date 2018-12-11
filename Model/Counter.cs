using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            _Meals = new List<Meal>();;
        }

        public void AddOrder(Order order)
        {
            _Orders.Add(order);
        }
        public void AddOrders(Order[] orders)
        {
            _Orders.AddRange(orders);
        }

        public void AddMeal(Meal meal)
        {
            _Meals.Add(meal);
        }
        public void AddMeals(Meal[] meals)
        {
            _Meals.AddRange(meals);
        }

        public Meal[] TakeMeals()
        {
            Meal[] meals = _Meals.ToArray();
            _Meals.Clear();
            return meals; 
        }
        public Order[] TakeOrders()
        {
            Order[] orders = _Orders.ToArray();
            _Orders.Clear();
            return orders;
        }

        public static T Deserialize<T>(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(stream);
            }
        }

        public static byte[] Serialize<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Flush();
                stream.Position = 0;
                return stream.ToArray();
            }
        }

        

    }
}
