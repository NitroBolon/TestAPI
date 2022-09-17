using AutoMapper;
using LicensesAPI.Models;

namespace LicensesAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LicenseType, LicenseTypeDto>();
        }
    }
}
