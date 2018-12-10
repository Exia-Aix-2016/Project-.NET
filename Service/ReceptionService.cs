using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReceptionService
    {
        private DiningRoom DiningRoom;

        public ReceptionService(DiningRoom diningRoom)
        {
            this.DiningRoom = diningRoom;
        }

        public Client[] GetNewClients()
        {
            Random random = new Random();

            int nbrRandClient = random.Next(1, 10);

            Client[] clients = new Client[nbrRandClient];

            for(int i = 0; i < clients.Length; i++)
            {
                clients[i] = new Client();
            }

            return clients;

        }

        public bool IsMenuAvailable(int number)
        {
            if(DiningRoom.Menus.Count >= number)
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
