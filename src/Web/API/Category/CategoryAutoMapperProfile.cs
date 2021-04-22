using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Category
{
    public class CategoryAutoMapperProfile : Profile
    {

        public CategoryAutoMapperProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
        }
    }
}
