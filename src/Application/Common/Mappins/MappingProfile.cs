using AutoMapper;
using BasketAppApi.Application.Products.Models;
using BasketAppApi.Domain.Entities;

namespace BasketAppApi.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>()
            .ForMember(m => m.CreatedDate, map => map.Ignore())
            .ForMember(m => m.Id, map => map.Ignore());

            CreateMap<Product, ProductDto>();
        }
    }
}