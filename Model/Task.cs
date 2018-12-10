using System;
namespace Model
{
    public delegate void callback(params object[] param);
    public class Task : ITask
    {
        public readonly object[] Param;
        private callback _Callback;
        private object p1;
        private int v;
        private Action<object[]> p2;

        public Task(object[] param, int numberTicks, callback callback)
        {
            TickRemaining = numberTicks;
            _Callback = callback;
            Param = param;
            IsProcess = false;
        }

        public Task(object p1, int v, Action<object[]> p2)
        {
            this.p1 = p1;
            this.v = v;
            this.p2 = p2;
        }

        public void exec()
        {
           
            if (TickRemaining == 0)
            { 
                _Callback.Invoke(Param);
                IsProcess = true;
            }
            else
            {
                TickRemaining--;
            }

        }

        public bool IsProcess { get; private set; }

        public int TickRemaining { get; private set; }
    }
}
