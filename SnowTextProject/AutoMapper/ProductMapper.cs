using AutoMapper;
using SnowTextProject.Dtos;
using SnowTextProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.AutoMapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDto, Product>()
               .ForMember(dest => dest.PRODUCT_ID, act => act.MapFrom(src => src.ProuctId))
               .ForMember(dest => dest.PRODUCT_NAME, act => act.MapFrom(src => src.ProductName))
               .ForMember(dest => dest.IMAGE_NAME, act => act.MapFrom(src => src.ImageName))
               .ForMember(dest => dest.PHOTO_URL, act => act.MapFrom(src => src.PhotoUrl))
               .ForMember(dest => dest.IMAGE_DATA, act => act.MapFrom(src => src.ImageData))
               .ForMember(dest => dest.SIZE_ID, act => act.MapFrom(src => src.SizeId));

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProuctId, act => act.MapFrom(src => src.PRODUCT_ID))
                .ForMember(dest => dest.ProductName, act => act.MapFrom(src => src.PRODUCT_NAME))
                .ForMember(dest => dest.ImageName, act => act.MapFrom(src => src.IMAGE_NAME))
                .ForMember(dest => dest.PhotoUrl, act => act.MapFrom(src => src.PHOTO_URL))
                .ForMember(dest => dest.ImageData, act => act.MapFrom(src => src.IMAGE_DATA))
                .ForMember(dest => dest.SizeId, act => act.MapFrom(src => src.SIZE_ID));
        }
    }
}
