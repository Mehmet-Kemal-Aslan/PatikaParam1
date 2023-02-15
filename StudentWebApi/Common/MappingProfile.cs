using AutoMapper;
using StudentWebApi.Application.ProjectOperations.Queries;
using StudentWebApi.Models;

namespace StudentWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectViewModel>();
        }
    }
}
