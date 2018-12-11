using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WashingMachine : Container<Cloth>, ICleaningDevice<Cloth>, ITaskProcessorContainer
    {
        public int TimeRequire = 10;
        private ITaskProcessor _TaskProcessor;
        private bool _Available;


        public WashingMachine(int numberSlots) : base(numberSlots)
        {
            _TaskProcessor = new TaskProcessor();
            _Available = true;
        }
        public void AddDirtyCloth(Cloth cloth)
        {
            if (cloth == null) throw new ArgumentNullException("DisMachine : cloth is null");

            if (cloth.CleaningStatus == CleaningStatus.DIRTY)
            {
                base.AddItem(cloth);
            }
        }
        public void AddDirtyCloths(List<Cloth> cloths)
        {
            if (cloths == null) throw new ArgumentNullException("DisMachine : cloths is null");

            if (cloths.TrueForAll(tool => tool.CleaningStatus == CleaningStatus.DIRTY))
            {
                base.AddItems(cloths);
            }
        }
        public void StartMachine()
        {
            if (!_Available) return;

            _Available = false;

            TaskProcessor.AddTask(new Task((Void) => {

                Storage.ForEach(item => item.CleaningStatus = CleaningStatus.CLEAN);
                _Available = true;
            }, TimeRequire));
        }

        public List<Cloth> Retrieve()
        {
            List<Cloth> cloths = new List<Cloth>(Storage.Count);

            cloths.AddRange(Storage);
            Storage.Clear();

            return cloths;
        }

        public ITaskProcessor TaskProcessor { get; }

        public bool Available { get => _Available && !Storage.Any(); }
    }
}
