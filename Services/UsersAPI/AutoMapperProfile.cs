using AutoMapper;
using UsersAPI.Models;

namespace UsersAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>().ForMember(dest => dest.UserProperties,
            opt => opt.Ignore());

            CreateMap<UserPostDto, User>().ForMember(dest => dest.UserProperties,
            opt => opt.Ignore());

            CreateMap<UserPropertyDto, UserProperty>().ForMember(dest => dest.User,
            opt => opt.Ignore());

            CreateMap<UserPropertyPostDto, UserProperty>().ForMember(dest => dest.User,
            opt => opt.Ignore());
        }
    }
}
