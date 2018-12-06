using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bowl : Dishes
    {
        public void TestDataBase()
        {
            var db = new MarmitonContext();

            /*  var t = new DataAccess.Storage
              {
                  Lifetime = 5,
                  Location = "sd"
              };

              db.Storages.Add(t);

              db.SaveChanges();*/

            var res = db.Storages.First();

            Console.WriteLine("ok");
        }
    }
}
