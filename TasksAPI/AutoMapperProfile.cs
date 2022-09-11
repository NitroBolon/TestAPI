using AutoMapper;
using TasksAPI.Models;

namespace UsersAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskDto, TasksAPI.Models.Task>();

            CreateMap<TaskPostDto, TasksAPI.Models.Task>();

            CreateMap<TaskStateDto, TaskState>();

            CreateMap<TaskStatePostDto, TaskState>();
        }
    }
}
