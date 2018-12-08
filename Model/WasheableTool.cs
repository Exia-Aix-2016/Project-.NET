using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WasheableTool : Model.Tool
    {
        public bool Clean;
        public WasheableTool(ToolsType toolType) : base(toolType) { Clean = true; }

    }
}
