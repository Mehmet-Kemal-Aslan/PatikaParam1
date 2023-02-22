using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi.Application.MentorOperations.Queries.GetMentorDetail
{
    public class GetMentorDetailQuery
    {
        private readonly IStudentDbContext _dbContext;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetMentorDetailQuery(IStudentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MentorDetailViewModel Handle()
        {
            var mentor = _dbContext.Mentors.Include(x => x.Project).Where(mentor => mentor.MentorId == Id).SingleOrDefault();
            if (mentor == null)
                throw new InvalidOperationException("Mentör bulunamadı.");
            MentorDetailViewModel vm = _mapper.Map<MentorDetailViewModel>(mentor);

            return vm;
        }
    }

    public class MentorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Project { get; set; }
    }
}
