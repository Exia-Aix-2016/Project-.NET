using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sink
    {
        private List<WasheableTool> _WashingTools;
        public bool Available;

        public void addDirtyTool(WasheableTool tool) {
            if (tool.Clean) _WashingTools.Add(tool);
        }
        public void addDirtyTools(List<WasheableTool> tools)
        {
            tools.ForEach(tool =>
            {
                if (tool.Clean) _WashingTools.Add(tool);
            });
        }
        
        public List<WasheableTool> cleanTools()
        {
            if(_WashingTools.Count == 0) return null;

            //Set number Item can be get by Diver.
            Random random = new Random();
            int numItem = random.Next(1, 6);

            List<WasheableTool> tools = new List<WasheableTool>(numItem);
            
            tools.AddRange(_WashingTools.GetRange(0, numItem));
            tools.ForEach(tool => tool.Clean = true); 

            return tools;
  
        }
    }
}
