using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi.Application.MentorOperations.Queries.GetMentors
{
    public class GetMentorsQuery
    {
        private readonly StudentDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMentorsQuery(StudentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MentorViewModel> Handle()
        {
            var mentorList = _dbContext.Mentors.Include(x => x.Project).OrderBy(x => x.MentorId).ToList<Mentor>();
            List<MentorViewModel> vm = _mapper.Map<List<MentorViewModel>>(mentorList);

            return vm;
        }
    }

    public class MentorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Project { get; set; }
    }
}
