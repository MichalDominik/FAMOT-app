using AutoMapper;
using Fridge.API.Dtos.Category;
using Fridge.API.Dtos.Product;
using Fridge.Service.Models;

namespace Fridge.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Category, CategoryResultDto>().ReverseMap();
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductEditDto>().ReverseMap();
            CreateMap<Product, ProductResultDto>().ReverseMap();
        }
    }
}
