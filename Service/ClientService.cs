using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClientService : Service
    {

        private Configuration configuration => _injector.Get<Configuration>();
        private DiningRoom dining => _injector.Get<DiningRoom>();

        public ClientService(DependencyInjector injector) : base(injector)
        {
        }

        public void ChooseMeal(Table table)
        {
            Random random = new Random();
            Menu menu = table.Menus.First();
            table.Items().ForEach(client =>
            {
                string recipe = menu.Recipes[random.Next(0, menu.Recipes.Count - 1)];
                client.TaskProcessor.AddTask(() =>
                {
                    lock (dining.Squares)
                    {
                        client.Choice = recipe;
                    }
                }, configuration.TimeToChoose, "CHOOSING");
            });
        }

        public void Eat(Client client)
        {
            client.TaskProcessor.AddTask(() =>
            {
                lock (dining.Squares)
                {
                    client.Finished = true;
                }
            }, configuration.TimeToEat, "EATING");
        }

        public Client[] GetClients(Func<Client, bool> selector)
        {
            return dining.Clients.Where(selector).ToArray();
        }
    }
}
