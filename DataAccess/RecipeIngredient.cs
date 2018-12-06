
namespace DataAccess
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RecipeIngredient
    {
        [Key, Column(Order = 1)]
        public string IngredientTypeName;

        public IngredientType IngredientType { get; set; }

        [Key, Column(Order = 0)]
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int Quantity { get; set; }
    }
}
