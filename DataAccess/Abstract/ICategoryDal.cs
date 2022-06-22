using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        Task<List<Category>> GetCategory(Expression<Func<Category, bool>>? filters);
        Category GetByIdCategory(Expression<Func<Category, bool>>? filters);
        void AddCategory(CategoryDTO categoryDTO);
        void UpdateCategory(int id, CategoryDTO categoryDTO);
    }
}
