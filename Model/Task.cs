namespace Model
{
    public delegate T callback<T>(params object[] param);
    public class Task<T> : ITask
    {
        public readonly object[] Param;
        public readonly callback<T> Callback;
        private int tickRemaining;

        public Task(object[] param, callback<T> callback, int numberTicks)
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
