using System;
namespace Model
{
    public delegate void callback(params object[] param);
    public class Task : ITask
    { 
        private callback Callback;
        public int TickRemaining { get; private set; }
        public bool IsProcess { get; private set; } = false;

        public Task(callback callback, int ticks = 1)
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
