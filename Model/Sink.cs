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
    
            //Set number Item can be get by Diver.
            Random random = new Random();
            int numItem = random.Next(1, 6);

            List<WasheableTool> tools = new List<WasheableTool>(numItem);
            
            tools.AddRange(Storage.GetRange(0, numItem));
            tools.ForEach(tool => tool.CleaningStatus = CleaningStatus.RINSE);

            tools.ForEach(t => Storage.Remove(t));

            return tools;
        }

        public override void AddItem(WasheableTool item)
        {
            if (item.CleaningStatus == CleaningStatus.DIRTY) base.AddItem(item);
        }

        public override void AddItems(ref List<WasheableTool> items)
        {
           if(items.TrueForAll(item => item.CleaningStatus == CleaningStatus.DIRTY))
            {
                base.AddItems(ref items);
            }
            else
            {
                throw new Exception("Sink : There are item not dirty");
            }
           
        }
    }
}
