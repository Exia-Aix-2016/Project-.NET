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
        public readonly WasheableTool[] WasheableTools;

        public MessageSocket(Order[] orders) => Orders = orders;
        public MessageSocket(Meal[] meals) => Meals = meals;

        public MessageSocket(WasheableTool[] washeableTools) => WasheableTools = washeableTools;

        public MessageSocket(Order[] orders, Meal[] meals, WasheableTool[] washeableTool)
        {
            Orders = orders;
            Meals = meals;
            WasheableTools = washeableTool;
        }


        public bool HasOrders { get => (Orders.Length > 0) ? true : false; }
        public bool HasMeals { get => (Meals.Length > 0) ? true : false; }

        public bool HasWasheableTools { get => (WasheableTools.Length > 0) ? true : false; }

        public override string ToString()
        {
            string message = "";

            if(Orders != null)
            {
                Console.WriteLine("Orders : ");

                for (int i = 0; i < Orders.Length; i++)
                {
                    message += Orders[i].Recipe.Name;
                    message += $"nbr ingredients : {Orders[i].Recipe.Ingredients.Count()}";
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

            if(WasheableTools != null)
            {
                Console.WriteLine("WasheableTool : ");
                for (int i = 0; i < WasheableTools.Length; i++) message += WasheableTools[i].ToolsType + " : " + WasheableTools[i].CleaningStatus;
                message += "\n\n";
            }
            return message;
        }


    }
}
