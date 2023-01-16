
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CookBook.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Directions { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
