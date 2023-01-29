using CookBook.Areas.Identity.Data;
using CookBook.Entities;
using CookBook.Interfaces;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CookBook.Services
{
    public class RecipeService : IRecipeService
    {
        public readonly CookBookDbContext _context;
        public readonly IMapper<Recipe, RecipeModel> _recipeMapper;

        public RecipeService(CookBookDbContext context, IMapper<Recipe, RecipeModel> mapper)
        {
            _context = context;
            _recipeMapper = mapper;
        }

        public List<RecipeModel> GetAllRecipes()
        {
            return _context.Recipes.Select(x => _recipeMapper.MapFromEntityToModel(x)).ToList();
        }

        public RecipeModel GetRecipe(int Id)
        {
            var entity = _context.Recipes.Find(Id);
            if (entity == null)
            {
                return new RecipeModel() { };
            }
            return _recipeMapper.MapFromEntityToModel(entity);
        }        
        public RecipeModel CreateRecipe(RecipeModel recipe)
        {
            recipe.CategoryId = _context.Categories.Where(x => x.Name == recipe.Category.Name).Select(x => x.Id).FirstOrDefault();
            var recipeEntity = _recipeMapper.MapFromModelToEntity(recipe);
            recipeEntity.CreateDate = DateTime.Now;
            _context.Recipes.Add(recipeEntity);
            _context.SaveChanges();
            recipe = _recipeMapper.MapFromEntityToModel(recipeEntity);
            return recipe;
        }
        public RecipeModel EditRecipe(RecipeModel recipe)
        {
            recipe.CategoryId = _context.Categories.Where(x => x.Name == recipe.Category.Name).Select(x => x.Id).FirstOrDefault();
            _context.Recipes.Update(_recipeMapper.MapFromModelToEntity(recipe));
            _context.SaveChanges();
            return recipe;
        }
        public void DeleteRecipe(int Id)
        {
            var cat = _context.Recipes.Find(Id);
            if (cat == null)
            {
                throw new Exception();
            }
            _context.Recipes.Remove(cat);
            _context.SaveChanges();
        }

    }
}
