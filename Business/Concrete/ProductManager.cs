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
    public class ProductManager : IProductService
    {
        IProductDal _dal;

        public ProductManager(IProductDal dal)
        {
            _dal = dal;
        }

        public void Add(ProductDTO product)
        {
            _dal.AddProduct(product);
        }

        public void Delete(int? id)
        {
            if (id == null) return;
            var product = _dal.Get(c => c.Id == id);
            product.IsDeleted=true;
            _dal.Update(product);

        }

        public async Task<List<Product>> GetAll()
        {
            return await _dal.GetProducts(c => !c.IsDeleted);
        }   

        public Product GetById(int? id)
        {
            if (id == null) return null;
            return _dal.Get(c => c.Id == id);

        }

        public void Update(int id,ProductDTO productdto)
        {
            Product selectedPro = _dal.Get(c => c.Id == id);
            selectedPro.Name = productdto.Name;
            selectedPro.Price = productdto.Price;
            selectedPro.Description = productdto.Description;
            selectedPro.Discount = productdto.Discount;
            selectedPro.CategoryId = productdto.CategoryId;

            _dal.Update(selectedPro);
        }
    }
}
