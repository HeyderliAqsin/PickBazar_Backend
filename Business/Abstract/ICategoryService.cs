using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Category GetById(int? id);
        void Update(int id,CategoryDTO category);
        void Delete(int? id);
        void Add(CategoryDTO category);
    }
}
