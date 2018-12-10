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
            return null;

        }

        public bool IsMenuAvailable(int number)
        {
            return false;
        }
    }
}
