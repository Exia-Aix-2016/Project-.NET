using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rank
    {
        private Table[] Tables;

        public Rank(Table[] tables)
        {
            this.Tables = tables;
        }
    }
}
