using AutoMapper;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.MyProfiles
{
    public class ProductDetailProfile:Profile
    {
        public ProductDetailProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(
                    opt => opt.CategoryName,
                    des => des.MapFrom(src => src.Category.Name)
                )
                .ForMember(
                    opt => opt.Name,
                    des => des.MapFrom(src => src.Name)
                 )
                .ForMember(
                    opt => opt.Description,
                    des => des.MapFrom(src => src.Description)
                 );
        }
    }
}
