using CookBook.Models;

namespace CookBook.Interfaces
{
    public interface IRecipeService
    {
        List<RecipeModel> GetAllRecipes();
        RecipeModel GetRecipe(int Id);
        RecipeModel CreateRecipe(RecipeModel recipe);
        RecipeModel EditRecipe(RecipeModel recipe);

    }
}
