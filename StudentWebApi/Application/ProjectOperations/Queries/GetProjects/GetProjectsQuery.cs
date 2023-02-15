using AutoMapper;
using StudentWebApi.Models;

namespace StudentWebApi.Application.ProjectOperations.Queries
{
    public class GetProjectsQuery
    {
        public readonly StudentDbContext _context;
        public readonly IMapper _mapper;

        public GetProjectsQuery(StudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProjectViewModel> Handle()
        {
            var projects = _context.Projects.Where(p => p.IsActive).OrderBy(p => p.ProjectId);
            List<ProjectViewModel> returnObj = _mapper.Map<List<ProjectViewModel>>(projects);
            return returnObj;
        }
    }

    public class ProjectViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
