using AutoMapper;
using StudentWebApi.Models;

namespace StudentWebApi.Application.MentorOperations.Commands.CreateMentor
{
    public class CreateMentorCommand
    {
        public CreateMentorViewModel Model { get; set; }
        private readonly IStudentDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMentorCommand(IStudentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var mentor = _dbContext.Mentors.SingleOrDefault(x => x.Name == Model.Name);
            if (mentor != null)
                throw new InvalidOperationException("Aynı mentör ikinci kez kaydedilemez!");
            mentor = _mapper.Map<Mentor>(Model);
            _dbContext.Mentors.Add(mentor);
            _dbContext.SaveChanges();
        }
    }

    public class CreateMentorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int ProjectId { get; set; }
    }
}
