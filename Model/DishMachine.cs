using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DishMachine : Container<WasheableTool>,  ICleaningDevice<WasheableTool>, ITaskProcessorContainer
    {
        public static int TIME_REQUIRE;
        ITaskProcessor _TaskProcessor;
        private bool _Available;

        public DishMachine(int numberSlots) : base(numberSlots)
        {
            _TaskProcessor = new TaskProcessor();
            _Available = true;

        }

        public void AddDirtyTool(WasheableTool tool)
        {
            if (tool == null) throw new ArgumentNullException("DisMachine : tool is null");

            if(tool.CleaningStatus == CleaningStatus.DIRTY && tool.WashRequirement == WashRequirement.DishMachine)
            {
                base.AddItem(tool);
            }
        }
        public void AddDirtyTools(ref List<WasheableTool> tools)
        {
            if (tools == null) throw new ArgumentNullException("DisMachine : tool is null");

            if(tools.TrueForAll(tool => tool.CleaningStatus == CleaningStatus.DIRTY && tool.WashRequirement == WashRequirement.DishMachine))
            {
                base.AddItems(ref tools);
            }
        }

        public void StartMachine()
        {
            if (!_Available) return;

            _Available = false;
            TaskProcessor.AddTask(new Task(null, TIME_REQUIRE, (Void) =>
            {
                Storage.ForEach(tool => tool.CleaningStatus = CleaningStatus.CLEAN);
                _Available = true;

            }));
        }

        public List<WasheableTool> Retrieve()
        {
            List<WasheableTool> cloths = new List<WasheableTool>(Storage.Count);

            cloths.AddRange(Storage);
            Storage.Clear();

            return cloths;
        }

        public bool Available { get => !Storage.Any() && _Available; }

        public ITaskProcessor TaskProcessor { get; }
    }
}
