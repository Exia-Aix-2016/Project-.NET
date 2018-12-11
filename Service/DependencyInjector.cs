using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DependencyInjector
    {
        private IDictionary<object, object> _services = new Dictionary<object, object>();

        public void Register<T>(object service)
        {
            _services.Add(typeof(T), service);
        }

        public T Get<T>()
        {
            try
            {
                return (T)_services[typeof(T)];
            } catch
            {

            }

            return default(T);
        }
    }
}
