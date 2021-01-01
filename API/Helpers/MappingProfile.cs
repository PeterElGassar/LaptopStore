using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(src => src.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(src => src.ProductType.Name))
            .ForMember(d => d.ImageUrl, o => o.MapFrom<ProductUrlResolver>());


        }
    }
} 