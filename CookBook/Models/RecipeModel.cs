using CookBook.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CookBook.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Directions { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public Category Category { get; set; } = null!;
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; } = null!;
    }
}
