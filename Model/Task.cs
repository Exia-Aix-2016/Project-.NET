namespace Model
{
    public delegate void callback(params object[] param);
    public class Task : ITask
    {
        public readonly object[] Param;
        private callback _Callback;
        private int _TickRemaining;

        public Task(object[] param, int numberTicks, callback callback)
        {
            _TickRemaining = numberTicks;
            _Callback = callback;
            Param = param;
        }

        public void exec()
        {
            if (_TickRemaining == 0)
            {
                _Callback.Invoke(Param);
            }
            else
            {
                _TickRemaining--;
            }

        }

        public int TickRemaining { get => _TickRemaining; }
    }
}
