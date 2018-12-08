namespace DataAccess
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RecipeTool
    {
        [Key, Column(Order = 0)]
        public Recipe Recipe { get; set; }

        [Key, Column(Order = 1)]
        public ToolType ToolType { get; set; }

        public int Quantity { get; set; }
    }
}
