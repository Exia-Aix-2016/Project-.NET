using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WasheableTool : Tool
    {
        public CleaningStatus CleaningStatus;
        public WasheableTool(ToolsType toolType) : base(toolType) => CleaningStatus = CleaningStatus.CLEAN; 
        public WasheableTool(ToolsType toolType, CleaningStatus cleaningStatus) : base(toolType) => CleaningStatus = cleaningStatus;

    }
}
