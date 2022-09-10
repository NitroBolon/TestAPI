using AutoMapper;
using UsersAPI.Models;

namespace UsersAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>().ForMember(dest => dest.UserProperties,
            opt => opt.MapFrom(src => new List<UserProperty>()));
        }
    }
}
