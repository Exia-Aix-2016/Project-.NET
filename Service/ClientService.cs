using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClientService: Service
    {
        public ClientService(DependencyInjector injector) : base(injector)
        {
        }

        public void ChooseMeal(Table table)
        {
            table.Items().ForEach(client =>
            {
                client.TaskProcessor.AddTask(() =>
                {

                }, 10);
            });
        }

        public void Eat(Client client)
        {
            client.TaskProcessor.AddTask(() =>
            {
                client.Finished = true;
            }, 5);
        }
    }
}
