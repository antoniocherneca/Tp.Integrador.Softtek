using AutoMapper;
using Tp.Integrador.Softtek.DTOs;
using Tp.Integrador.Softtek.Entities;

namespace Tp.Integrador.Softtek
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserNoPassDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();

            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<Service, ServiceCreateDto>().ReverseMap();
            CreateMap<Service, ServiceUpdateDto>().ReverseMap();

            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, ProjectCreateDto>().ReverseMap();
            CreateMap<Project, ProjectUpdateDto>().ReverseMap();

            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Job, JobCreateDto>().ReverseMap();
            CreateMap<Job, JobUpdateDto>().ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, RoleCreateDto>().ReverseMap();
            CreateMap<Role, RoleUpdateDto>().ReverseMap();

            CreateMap<ProjectStatus, ProjectStatusDto>().ReverseMap();
            CreateMap<ProjectStatus, ProjectStatusCreateDto>().ReverseMap();
            CreateMap<ProjectStatus, ProjectStatusUpdateDto>().ReverseMap();
        }
    }
}
