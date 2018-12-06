namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class MarmitonContext: DbContext
    {
        public MarmitonContext(): base("MarmitonContext")
        {
        }

        public DbSet<Tool> Tools { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<IngredientType> IngredientTypes { get; set; }

        public DbSet<Storage> Storages { get; set; }
    }
}
