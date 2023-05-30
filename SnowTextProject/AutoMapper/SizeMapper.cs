using AutoMapper;
using SnowTextProject.Dtos;
using SnowTextProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.AutoMapper
{
    public class SizeMapper : Profile
    {
        public SizeMapper()
        {
            CreateMap<SizeDto, Size>()
                   .ForMember(dest => dest.SIZE_ID, act => act.MapFrom(src => src.SizeId))
                   .ForMember(dest => dest.SIZE_NAME, act => act.MapFrom(src => src.SizeName));

            CreateMap<Size, SizeDto>()
                .ForMember(dest => dest.SizeId, act => act.MapFrom(src => src.SIZE_ID))
                .ForMember(dest => dest.SizeName, act => act.MapFrom(src => src.SIZE_NAME));
        }
    }
}
