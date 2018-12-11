using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReceptionService: Service
    {

        private DiningRoom _diningRoom => _injector.Get<DiningRoom>();

        public ReceptionService(DependencyInjector injector) : base(injector)
        {
        }

        public void GenerateNewClients()
        {
            Random random = new Random();

            int nbrRandClient = random.Next(1, 10);

            Client[] clients = new Client[nbrRandClient];

            for(int i = 0; i < clients.Length; i++)
            {
                clients[i] = new Client();
            }

            _diningRoom.Lobby.Add(clients);
        }

        public Client[] GetNewClients()
        {
            return _diningRoom.Lobby.First();
        }

        public bool IsMenuAvailable(int number)
        {
            if(_diningRoom.Menus.Count >= number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
