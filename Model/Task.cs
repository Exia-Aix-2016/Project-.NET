namespace Model
{
    public delegate void callback(params object[] param);
    public class Task : ITask
    {
        public readonly object[] Param;
        private callback Callback;
        private int tickRemaining;

        public Task(object[] param, int numberTicks, callback callback)
        {
            tickRemaining = numberTicks;
            Callback = callback;
            Param = param;
        }

        public void exec()
        {
            if (tickRemaining == 0)
            {
                Callback.Invoke(Param);
            }
            else
            {
                tickRemaining--;
            }

        }

        public int TickRemaining { get => tickRemaining; }
    }
}
