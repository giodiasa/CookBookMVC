using CookBook.Interfaces;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
{
    public class RecipeController : Controller
    {
        public readonly IRecipeService _recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("GetAllRecipes")]
        public IActionResult Index()
        {
            List<RecipeModel> model = _recipeService.GetAllRecipes();
            return View(model);
        }

        [HttpGet("GetRecipe")]
        public IActionResult GetRecipe(int Id)
        {
            RecipeModel model = _recipeService.GetRecipe(Id);
            return View(model);
        }

        [HttpGet("CreateRecipe")]
        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost("CreateRecipe")]
        public IActionResult CreateRecipe(RecipeModel recipe)
        {
            _recipeService.CreateRecipe(recipe);
            return RedirectToAction("Index");
        }

        [HttpGet("EditRecipe")]
        public IActionResult EditRecipe(int? Id)
        {
            if(Id is null || Id == 0)
            {
                return NotFound();
            }
            var recipe = _recipeService.GetRecipe((int)Id);
            if(recipe is null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost("EditRecipe")]
        public IActionResult EditRecipe(RecipeModel recipe)
        {
            _recipeService.EditRecipe(recipe);
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteRecipe")]
        public IActionResult DeleteRecipe(int? Id)
        {
            if (Id is null || Id == 0)
            {
                return NotFound();
            }
            var recipe = _recipeService.GetRecipe((int)Id);
            if (recipe is null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost("DeleteRecipe")]
        public IActionResult Delete(int Id)
        {
            _recipeService.DeleteRecipe(Id);
            return RedirectToAction("Index");
        }
    }
}
