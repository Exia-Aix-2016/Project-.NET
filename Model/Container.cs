using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Container<T>
    {
        protected List<T> Storage;
        public readonly int NumberSlots;

        public Container(int numberSlots = 0)
        {
            Storage = getNewStorage<T>(numberSlots);
            NumberSlots = numberSlots;
        }


        /**
         * Construct new Storage with max or infinite Items. 0 = infinite. 
         */
        public static List<R> getNewStorage<R>(int numberSlots)
        {
            if (numberSlots > 0)
            {
                return new List<R>(numberSlots);
            }
            else
            {
                return new List<R>();
            }
        }
        public virtual int Size { get => Storage.Count; }
        public virtual void AddItem(T item)
        {
            if (item == null) throw new ArgumentNullException("Container : item null");

            if (NumberSlots > 0 && Storage.Count + 1 > NumberSlots) throw new Exception("Container : Storage is full");
            
            Storage.Add(item);
        }

        public virtual void AddItems(List<T> items)
        {
            if (items == null) throw new ArgumentNullException("Container : items null");
            if (NumberSlots > 0 && Storage.Count + items.Count > NumberSlots) throw new Exception("Container : Storage is full");
            Storage.AddRange(items);
        }

        public virtual void removeItem(T item)
        {
            if (item == null) throw new ArgumentNullException("Container : item null");
            Storage.Remove(item);
        }
        public virtual T RemoveItem(int index)
        {
            if (index > Storage.Count) throw new IndexOutOfRangeException("out of bound");

            T item = Storage.ElementAt(index);
            if (item != null) Storage.Remove(item);
            return item;
        }

        public virtual T Item(int index)
        {
            if (index > Storage.Count) throw new IndexOutOfRangeException("Out of bound");
            return Storage.ElementAt(index);
        }

        public virtual List<T> Items()
        {
            return Storage;
        }

        public virtual void Clear()
        {
            Storage.Clear();
        }
    }
 

    
}
