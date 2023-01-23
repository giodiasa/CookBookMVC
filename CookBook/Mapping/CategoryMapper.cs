using CookBook.Entities;
using CookBook.Interfaces;
using CookBook.Models;

namespace CookBook.Mapping
{
    public class CategoryMapper : IMapper<Category, CategoryModel>
    {
        public CategoryModel MapFromEntityToModel(Category source)
        {
            return new CategoryModel
            {
                Id = source.Id,
                Name = source.Name
            };
        }

        public Category MapFromModelToEntity(CategoryModel source)
        {
            var entity = new Category();
            MapFromModelToEntity(source, entity);
            return entity;
        }

        public void MapFromModelToEntity(CategoryModel source, Category target)
        {
            target.Id = source.Id;
            target.Name = source.Name;
        }
    }
}
