using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiriLavMad.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ingredientsModel> extendedIngredients { get; set; }
        public string summary { get; set; }
        public string instructions { get; set; }

        public Recipe()
        {

        }


    }
}
