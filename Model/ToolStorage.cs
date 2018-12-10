using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ToolStorage : Container<Tool>
    {
        public ToolStorage(int numberSlot) : base(numberSlot) { }

        public Tool TakeTool(ToolsType toolsType)
        {
            Tool tool =  Storage.First(item => item.ToolsType == toolsType);
            base.removeItem(tool);
            return tool;
        }
    }
}
