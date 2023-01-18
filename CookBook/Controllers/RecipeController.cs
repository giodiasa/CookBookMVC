using CookBook.Interfaces;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CookBook.Controllers
{
    public class RecipeController : Controller
    {
        public readonly IRecipeService _recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("[controller]/GetAllRecipes")]
        public IActionResult Index(int? page, string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var model = _recipeService.GetAllRecipes().OrderByDescending(r => r.CreateDate);
            PagedList<RecipeModel> pagedModel = (PagedList<RecipeModel>)model.ToPagedList(page ?? 1, 16);

            if (!string.IsNullOrEmpty(SearchString))
            {
                pagedModel = (PagedList<RecipeModel>)pagedModel.Where(r => r.Name.ToLower().Contains(SearchString.ToLower())).ToPagedList();
            }
            return View(pagedModel);
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
