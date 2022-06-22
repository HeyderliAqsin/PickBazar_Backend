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
    public class EfProductDal : EfEntityRepositoryBase<Product, PickBazarContext>, IProductDal
    {

        public void AddProduct(ProductDTO productDTO)
        {
            Product newProduct = new()
            {
                Price = productDTO.Price,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Discount = productDTO.Discount,
                CategoryId=productDTO.CategoryId,

            };
            using PickBazarContext context = new();
            context.Add(newProduct);
            context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>>? filters = null)
        {
            using PickBazarContext context = new();
            var product = context.Products
                .Include(c => c.Category)
                .FirstOrDefault(filters);
            return product;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>>? filters = null)
        {
            throw new NotImplementedException();
        }

        public Product GetById(Expression<Func<Product, bool>>? filters)
        {
            throw new NotImplementedException();

        }

        public async Task<List<Product>> GetProducts(Expression<Func<Product, bool>>? filters)
        {
            using PickBazarContext context=new();
            var products = context.Products
                .Include(c => c.Category)
                .AsQueryable();
            if(filters != null)
            {
                products = products.Where(filters);
            }
            return await products.ToListAsync();
        }

        public void UpdateProduct(int Id, ProductDTO productDTO)
        {
            using PickBazarContext context = new();

            Product newProduct = new()
            {
                Price = productDTO.Price,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Discount = productDTO.Discount,
                CategoryId = productDTO.CategoryId,

            };

            context.Update(newProduct);
            context.SaveChanges();

        }
    }
}
