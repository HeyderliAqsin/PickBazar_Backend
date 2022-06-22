using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Product GetById(int? id);
        void Add(ProductDTO product);
        void Update(int id,ProductDTO product);
        void Delete(int? id);
    }
}
