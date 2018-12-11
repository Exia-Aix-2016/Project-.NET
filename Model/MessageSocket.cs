using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class MessageSocket
    {
        public readonly Order[] Orders;
        public readonly Meal[] Meals;

        public MessageSocket(Order[] orders) => Orders = orders;
        public MessageSocket(Meal[] meals) => Meals = meals;
        public MessageSocket(Order[] orders, Meal[] meals)
        {
            Orders = orders;
            Meals = meals;
        }


        public bool HasOrders { get => (Orders.Length > 0) ? true : false; }
        public bool HasMeals { get => (Meals.Length > 0) ? true : false; }

        public override string ToString()
        {
            string message = "";

            if(Orders != null)
            {
                Console.WriteLine("Orders : ");

                for (int i = 0; i < Orders.Length; i++)
                {
                    message += Orders[i].Recipe;
                    message += "\n";
                }
                message += "\n\n";
            }
            if(Meals != null)
            {
                Console.WriteLine("Meals : ");
                for (int i = 0; i < Meals.Length; i++) message += Meals[i].Name;

                message += "\n\n";
            }
            return message;
        }


    }
}
