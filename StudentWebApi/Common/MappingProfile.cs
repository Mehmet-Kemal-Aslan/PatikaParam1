using AutoMapper;
using StudentWebApi.Application.ProjectOperations.Queries;
using StudentWebApi.Models;
using static StudentWebApi.Application.ProjectOperations.Queries.GetProjectDetailQuery;
using static StudentWebApi.Operations.CreateStudents.CreateStudentsCommand;

namespace StudentWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateStudentModel, Student>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<Project, ProjectDetailViewModel>();
        }
    }
}
