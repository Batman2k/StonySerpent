using AutoMapper;
using StonySerpent.Core.Models;
using StonySerpent.Core.ViewModels;

namespace StonySerpent.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductSpecification>();
            CreateMap<Product, ProductCategory>();
            CreateMap<Product, ProductFormViewModel>();

            CreateMap<ProductCategory, ProductFormViewModel>();
            CreateMap<ProductSpecification, ProductFormViewModel>();

            CreateMap<ProductFormViewModel, Product>();
            CreateMap<ProductFormViewModel, ProductSpecification>();
            CreateMap<ProductFormViewModel, ProductCategory>();
        }
    }
}