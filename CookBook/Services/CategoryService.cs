using CookBook.Areas.Identity.Data;
using CookBook.Entities;
using CookBook.Interfaces;
using CookBook.Mapping;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CookBook.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly CookBookDbContext _context;
        public readonly IMapper<Category, CategoryModel> _categoryMapper;

        public CategoryService(CookBookDbContext context, IMapper<Category, CategoryModel> mapper)
        {
            _context = context;
            _categoryMapper = mapper;
        }

        public List<CategoryModel> GetAllCategories()
        {
            return _context.Categories.Select(x => _categoryMapper.MapFromEntityToModel(x)).ToList();
        }

        public CategoryModel GetCategory(int Id)
        {
            var entity = _context.Categories.Find(Id);
            if (entity == null)
            {
                return new CategoryModel() { };
            }
            return _categoryMapper.MapFromEntityToModel(entity);
        }
        public CategoryModel CreateCategory(CategoryModel category)
        {
            var categoryEntity = _categoryMapper.MapFromModelToEntity(category);
            _context.Categories.Add(categoryEntity);
            _context.SaveChanges();
            category = _categoryMapper.MapFromEntityToModel(categoryEntity);
            return category;
        }
        public void DeleteCategory(int Id)
        {
            var cat = _context.Categories.Find(Id);
            if (cat == null)
            {
                throw new Exception();
            }
            if(_context.Recipes.Where(x=> x.CategoryId == Id).Any())
            {
                throw new Exception();
            }
            _context.Categories.Remove(cat);
            _context.SaveChanges();
        }
        public CategoryModel EditCategory(CategoryModel category)
        {
            _context.Categories.Update(_categoryMapper.MapFromModelToEntity(category));
            _context.SaveChanges();
            return category;
        }
    }
}
