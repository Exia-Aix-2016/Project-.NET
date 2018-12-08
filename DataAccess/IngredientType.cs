namespace DataAccess
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class IngredientType
    {
        [Key]
        public string Name { get; set; }

        public Storage Storage { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
