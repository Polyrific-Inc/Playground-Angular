using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Product
{
    public class ProductAutoMapperProfile : Profile
    {

        public ProductAutoMapperProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
        }
    }
}
