using CookBook.Models;

namespace CookBook.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAllCategories();
        CategoryModel CreateCategory(CategoryModel category);
        void DeleteCategory(int Id);
        CategoryModel GetCategory(int Id);
        CategoryModel EditCategory(CategoryModel category);
    }
}
