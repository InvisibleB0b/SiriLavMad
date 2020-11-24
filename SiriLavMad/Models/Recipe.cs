using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiriLavMad.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public DateTime LastMade { get; set; }

        public Recipe()
        {

        }

        public Recipe(int recipeId, string recipeTitle, DateTime lastMade)
        {
            RecipeId = recipeId;
            RecipeTitle = recipeTitle;
            LastMade = lastMade;
        }

        public override string ToString()
        {
            return $"{nameof(RecipeId)}: {RecipeId}, {nameof(RecipeTitle)}: {RecipeTitle}, {nameof(LastMade)}: {LastMade}";
        }
    }
}
