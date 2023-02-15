using AutoMapper;
using StudentWebApi.Models;

namespace StudentWebApi.Application.ProjectOperations.Queries
{
    public class GetProjectDetailQuery
    {
        public int QueryId { get; set; }
        public readonly StudentDbContext _context;
        public readonly IMapper _mapper;

        public GetProjectDetailQuery(StudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProjectDetailViewModel Handle()
        {
            var project = _context.Projects.Where(p => p.IsActive && p.ProjectId == QueryId);
            if (project is null)
                throw new InvalidOperationException("Proje bulunamadı.");
            return _mapper.Map<ProjectDetailViewModel>(project);
        }
        public class ProjectDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
