using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ICookDevice : IAvailable
    {
        void AddRecipe(Recipe recipe);
        Meal TakeMeal { get; }
        bool IsCookFinished {get;}


    }
}
