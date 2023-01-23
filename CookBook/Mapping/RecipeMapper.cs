using CookBook.Entities;
using CookBook.Interfaces;
using CookBook.Models;

namespace CookBook.Mapping
{
    public class RecipeMapper : IMapper<Recipe, RecipeModel>
    {
        public RecipeModel MapFromEntityToModel(Recipe source)
        {
            return new RecipeModel
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Directions = source.Directions,
                CreateDate = source.CreateDate,
                CategoryId = source.CategoryId,
            };
        }

        public Recipe MapFromModelToEntity(RecipeModel source)
        {
            var entity = new Recipe();
            MapFromModelToEntity(source, entity);
            return entity;
        }

        public void MapFromModelToEntity(RecipeModel source, Recipe target)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Directions = source.Directions;
            target.CreateDate = source.CreateDate;
            target.CategoryId = source.CategoryId;
        }
    }
}
