using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DirtyStorage
    {
        public readonly Cloth[] Cloths;
        public readonly Tool[] Tools;

        public DirtyStorage(Cloth[] cloths, Tool[] tools)
        {
            this.Cloths = cloths;
            this.Tools = tools;
        }
    }
}
