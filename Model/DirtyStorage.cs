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
        public readonly WasheableTool[] Tools;

        public DirtyStorage(Cloth[] cloths, WasheableTool[] tools)
        {
            this.Cloths = cloths;
            this.Tools = tools;
        }
    }
}
