using AutoMapper;
using SnowTextProject.Dtos;
using SnowTextProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.AutoMapper
{
    public class PasswordMapper : Profile
    {
        public PasswordMapper()
        {
            CreateMap<PasswordDto, ForgetPassword>()
               .ForMember(dest => dest.PASSWORD_RESET_ID, act => act.MapFrom(src => src.PasswordResetId))
               .ForMember(dest => dest.USER_ID, act => act.MapFrom(src => src.UserID));

            CreateMap<ForgetPassword, PasswordDto>()
                .ForMember(dest => dest.PasswordResetId, act => act.MapFrom(src => src.PASSWORD_RESET_ID))
                .ForMember(dest => dest.UserID, act => act.MapFrom(src => src.USER_ID));
        }
    }
}
