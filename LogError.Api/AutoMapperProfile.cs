using AutoMapper;
using LogError.Domain.DTO;
using LogError.Domain.Entities;

namespace LogError.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, AddUserDTO>().ReverseMap();
            CreateMap<LogInfo, LogInfoDTO>().ReverseMap();
            CreateMap<LogInfo, AddLogInfoDTO>().ReverseMap();
            CreateMap<LogDetail, LogDetailDTO>().ReverseMap();
            CreateMap<LogDetail, AddLogDetailDTO>().ReverseMap();
        }
    }
}
