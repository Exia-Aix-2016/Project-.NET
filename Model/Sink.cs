using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sink : Container<WasheableTool>
    {
        public Sink(int numberSlots) : base(numberSlots){}
       
        public List<WasheableTool> WashingTools()
        {
            if(Storage.Count == 0) throw new Exception(" Sink : You cannot Washing tools when the Sink is empty !");

            List<WasheableTool> tools = new List<WasheableTool>();

            Storage.ForEach(tool => {
                tool.CleaningStatus = CleaningStatus.CLEAN;
                tools.Add(tool);
                });
            Storage.Clear();

            return tools;
        }

        public override void AddItem(WasheableTool item)
        {
            if (item.CleaningStatus == CleaningStatus.DIRTY && item.WashRequirement == WashRequirement.Sink) base.AddItem(item);
        }

        public override void AddItems(List<WasheableTool> items)
        {
           if(items.TrueForAll(item => item.CleaningStatus == CleaningStatus.DIRTY && item.WashRequirement == WashRequirement.Sink))
            {
                base.AddItems(items);
            }
            else
            {
                throw new Exception("Sink : There are item not dirty");
            }
           
        }
    }
}
