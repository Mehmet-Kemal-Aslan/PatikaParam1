using AutoMapper;
using StudentWebApi.Application.ProjectOperations.Queries;
using StudentWebApi.Models;
using static StudentWebApi.Application.ProjectOperations.Queries.GetProjectDetailQuery;
using static StudentWebApi.Operations.CreateStudents.CreateStudentsCommand;
using static StudentWebApi.Operations.GetStudentDetail.GetStudentDetailQuery;
using static StudentWebApi.Operations.GetStudentsQuery;

namespace StudentWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateStudentModel, Student>();
            CreateMap<Student, StudentDetailViewModel>().ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project.Name));
            CreateMap<Student, StudentViewModel>().ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project.Name));
            CreateMap<Project, ProjectViewModel>();
            CreateMap<Project, ProjectDetailViewModel>();
        }
    }
}
