using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Configuration
    {
        public int TimeToChoose = 300;

        public int TimeToOrder = 30;

        public int TimeToAssignTable = 90;

        public int TimeToSendOrdersToKitchen = 45;

        public int TimeToAssignMenus = 60;

        public int TimeToServeBread = 45;

        public int TimeToServeWater = 45;

        public int TimeToServeMeal = 120;

        public int TimeToCleanTable = 200;
    }
}
