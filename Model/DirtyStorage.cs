using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DirtyStorage
    {
        public readonly List<Cloth> Cloths;
        public readonly List<WasheableTool> WasheableTools;

        public DirtyStorage()
        {
            Cloths = new List<Cloth>();
            WasheableTools = new List<WasheableTool>();
        }
    }
}
