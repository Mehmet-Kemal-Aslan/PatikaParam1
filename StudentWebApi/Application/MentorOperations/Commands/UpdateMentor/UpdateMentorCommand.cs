using StudentWebApi.Models;

namespace StudentWebApi.Application.MentorOperations.Commands.UpdateMentor
{
    public class UpdateMentorCommand
    {
        private readonly StudentDbContext _dbContext;
        public int Id { get; set; }
        public UpdateMentorViewModel Model { get; set; }
        public UpdateMentorCommand(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var mentor = _dbContext.Mentors.SingleOrDefault(mentor => mentor.MentorId == Id);
            if (mentor == null)
                throw new InvalidOperationException("Güncellenecek mentör bulunamadı.");
            mentor.ProjectId = Model.ProjectId != default ? Model.ProjectId : mentor.ProjectId;
            mentor.BirthDate = Model.BirthDate != default ? Model.BirthDate : mentor.BirthDate;
            _dbContext.SaveChanges();
        }
    }

    public class UpdateMentorViewModel
    {
        public DateTime BirthDate { get; set; }
        public int ProjectId { get; set; }
    }
}
