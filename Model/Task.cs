using System;
namespace Model
{
    public delegate void callback(params object[] param);
    public class Task : ITask
    {
        public readonly object[] Param;
        private callback _Callback;
        private int _TickRemaining;
        private bool _Process;

        public Task(object[] param, int numberTicks, callback callback)
        {
            _TickRemaining = numberTicks;
            _Callback = callback;
            Param = param;
            _Process = false;
        }

        public void exec()
        {
           
            if (_TickRemaining == 0)
            { 
                _Callback.Invoke(Param);
                _Process = true;
            }
            else
            {
                _TickRemaining--;
            }

        }

        public bool IsProcess => _Process;

        public int TickRemaining => _TickRemaining;
    }
}
