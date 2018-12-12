using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class DinnerBootstrap : IBootstrap
    {
        public DependencyInjector Bootstrap()
        {
            List<string> recipe = new List<string>();

            recipe.Add("caviar");
            recipe.Add("Calamar");



            DependencyInjector injector = new DependencyInjector();

            DiningRoom diningRoom = new DiningRoom()
            {
                ClerkWaiter = new ClerkWaiter()
            };
            diningRoom.Menus.Add(new Menu(recipe));
            diningRoom.Menus.Add(new Menu(recipe));
            diningRoom.Menus.Add(new Menu(recipe));

            Square square1 = new Square(1, 1)
            {
                HeadWaiter = new HeadWaiter()
            };
            square1.Waiters.Add(new Waiter());
            square1.Waiters.Add(new Waiter());
            Rank rank1 = new Rank(3);
            Table table1 = new Table(1, 10);

            
            rank1.AddItem(table1);
            Table table2 = new Table(2, 3);
            rank1.AddItem(table2);
            Table table3 = new Table(3, 5);


            rank1.AddItem(table3);
            square1.AddItem(rank1);

            diningRoom.Squares.Add(square1);

            injector.Register<DiningRoom>(diningRoom);
            injector.Register<ClientService>(new ClientService(injector));
            injector.Register<ReceptionService>(new ReceptionService(injector));
            injector.Register<TableService>(new TableService(injector));
            injector.Register<DinnerStaffService>(new DinnerStaffService(injector));
            injector.Register<CounterClientService>(new CounterClientService(injector));
            injector.Register<Configuration>(new Configuration());

            return injector;
        }
 
    }
}
