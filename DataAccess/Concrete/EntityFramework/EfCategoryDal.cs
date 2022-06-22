using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, PickBazarContext>, ICategoryDal
    {
        public void AddCategory(CategoryDTO categoryDTO)
        {
            Category newcategory = new Category()
            {
                Name=categoryDTO.Name,
                Description=categoryDTO.Description,
                SanitizedName=categoryDTO.SanitizedName,

            };
            using PickBazarContext context = new();
            context.Add(newcategory);
            context.SaveChanges();
        }

        public Category GetByIdCategory(Expression<Func<Category, bool>>? filters)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetCategory(Expression<Func<Category, bool>>? filters)
        {
            using PickBazarContext context = new();
            var categories = context.Categories
                .AsQueryable();
            if (filters != null)
            {
                categories = categories.Where(filters);
            }
            return await categories.ToListAsync();
        }

        public void UpdateCategory(int id, CategoryDTO categoryDTO)
        {
            using PickBazarContext context = new();

            Category newCategory = new()
            {
                SanitizedName = categoryDTO.SanitizedName,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
        

            };
            context.Update(newCategory);
            context.SaveChanges();
        }
    }
}
