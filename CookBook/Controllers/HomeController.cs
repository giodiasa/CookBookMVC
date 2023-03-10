using CookBook.Interfaces;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CookBook.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IRecipeService _recipeService;

        public HomeController(ILogger<HomeController> logger, IRecipeService recipeService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _logger = logger;
            _recipeService = recipeService; 
        }

        public IActionResult Index()
        {
            var model = _recipeService.GetAllRecipes();
            model = model.OrderByDescending(r => r.CreateDate).ToList();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}