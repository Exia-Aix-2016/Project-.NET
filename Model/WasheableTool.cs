using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class WasheableTool : Tool
    {
        public readonly WashRequirement WashRequirement;

        public CleaningStatus CleaningStatus;
        public WasheableTool(ToolsType toolType, WashRequirement washRequirement) : base(toolType)
        {
            CleaningStatus = CleaningStatus.CLEAN;
            WashRequirement = washRequirement;

        }
        public WasheableTool(ToolsType toolType, WashRequirement washRequirement, CleaningStatus cleaningStatus) : base(toolType)
        {
            CleaningStatus = cleaningStatus;
            WashRequirement = washRequirement;
        }
    }
}
