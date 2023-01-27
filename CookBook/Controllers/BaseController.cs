using CookBook.Interfaces;
using CookBook.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CookBook.Controllers
{
    public class BaseController : Controller
    {
        private readonly IServiceProvider serviceProvider;

        public BaseController(IServiceProvider serviceProvider)
        {            
            this.serviceProvider = serviceProvider;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var categoryService = serviceProvider.GetService<ICategoryService>();
            ViewBag.Categories = categoryService?.GetAllCategories();
            base.OnActionExecuting(context);
        }
    }
}
