using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Storage
    {
        [Key]
        public string Location { get; set; }

        public int Lifetime;
    }
}
