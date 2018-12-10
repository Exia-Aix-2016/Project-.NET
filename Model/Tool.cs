using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tool
    {
        public readonly ToolsType ToolsType;
        public readonly WashersType WasherType;

        public Tool(ToolsType toolType, WashersType washerType)
        {
            ToolsType = toolType;
            WasherType = washerType;
        }




    }
}
