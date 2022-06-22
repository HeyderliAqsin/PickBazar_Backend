using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _dal;

        public CategoryManager(ICategoryDal dal)
        {
            _dal = dal;
        }


        public void Add(CategoryDTO category)
        {
            _dal.AddCategory(category);
        }

        public void Delete(int? id)
        {
            if (id == null) return;
            var category = _dal.Get(c => c.Id == id);
            category.IsDeleted = true;
            _dal.Update(category);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _dal.GetCategory(c=>!c.IsDeleted);
        }

        public Category? GetById(int? id)
        {
            if (id == null) return null;
            return _dal.Get(c => !c.IsDeleted && c.Id == id);

        }

        public void Update(int id, CategoryDTO category)
        {
            Category selectedCat = _dal.Get(c => c.Id == id);
            selectedCat.SanitizedName=category.SanitizedName;
            selectedCat.Name = category.Name;
            selectedCat.Description = category.Description;

            _dal.Update(selectedCat);
        }

    }
}
