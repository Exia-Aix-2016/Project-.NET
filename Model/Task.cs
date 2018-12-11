using System;
namespace Model
{
    public class Task : ITask
    { 
        private Action Callback;
        public int TickRemaining { get; private set; }
        public bool IsProcess { get; private set; } = false;

        public Task(Action callback, int ticks = 1)
        {
            TickRemaining = ticks;
            Callback = callback;
        }

        public void Exec()
        {
           
            if (TickRemaining == 0)
            { 
                if (Callback != null)
                {
                    Callback.Invoke();
                }
                IsProcess = true;
            }
            else
            {
                TickRemaining--;
            }

        }
    }
}
