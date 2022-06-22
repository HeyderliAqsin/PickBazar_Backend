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
    public interface IProductDal:IEntityRepository<Product>
    {
        Task<List<Product>> GetProducts(Expression<Func<Product, bool>>? filters);
        Product GetById(Expression<Func<Product, bool>>? filters);
        void AddProduct(ProductDTO productDTO);
        void UpdateProduct(int id,ProductDTO productDTO);
    }
}
