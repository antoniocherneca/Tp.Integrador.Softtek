using AutoMapper;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<ProjectStatus, ProjectStatusDto>().ReverseMap();
        }
    }
}
