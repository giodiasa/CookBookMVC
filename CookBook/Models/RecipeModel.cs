namespace CookBook.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Directions { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
