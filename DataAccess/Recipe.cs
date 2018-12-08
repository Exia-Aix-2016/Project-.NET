namespace DataAccess
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Recipe
    {
        [Key]
        public string Name { get; set; }

        public int CookingMinutes;

        public int BakingMinutes;

        public virtual ICollection<RecipeTool> RecipeTools { get; set; }

        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}
