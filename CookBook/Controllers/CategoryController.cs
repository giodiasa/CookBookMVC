using CookBook.Interfaces;
using CookBook.Models;
using CookBook.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CookBook.Controllers
{
    public class CategoryController : BaseController
    {
        public readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var model = _categoryService.GetAllCategories();            
            return View(model);
        }
        [HttpGet("CreateCategory")]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CategoryModel category)
        {
            _categoryService.CreateCategory(category);
            return RedirectToAction("CreateRecipe", "Recipe");
        }
        [HttpGet("DeleteCategory")]
        public IActionResult DeleteCategory(int? Id)
        {
            if (Id is null || Id == 0)
            {
                return NotFound();
            }
            var category = _categoryService.GetCategory((int)Id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost("DeleteCategory")]
        public IActionResult Delete(int Id)
        {
            _categoryService.DeleteCategory(Id);
            return RedirectToAction("CreateRecipe", "Recipe");
        }
        [HttpGet("EditCategory")]
        public IActionResult EditCategory(int? Id)
        {
            if (Id is null || Id == 0)
            {
                return NotFound();
            }
            var category = _categoryService.GetCategory((int)Id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost("EditCategory")]
        public IActionResult EditCategory(CategoryModel category)
        {
            _categoryService.EditCategory(category);
            return RedirectToAction("CreateRecipe", "Recipe");
        }
    }
}
