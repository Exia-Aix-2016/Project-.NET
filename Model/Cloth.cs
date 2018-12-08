using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cloth
    {
        public CleaningStatus CleaningStatus;
        public readonly ClothType ClothType;

        public Cloth(ClothType clothType) => ClothType = clothType;
        public Cloth(ClothType clothType, CleaningStatus cleaningStatus)
        {
            ClothType = clothType;
            CleaningStatus = cleaningStatus;
        }
    }
}
