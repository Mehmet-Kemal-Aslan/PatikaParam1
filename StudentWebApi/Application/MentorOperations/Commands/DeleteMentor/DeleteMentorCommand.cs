using StudentWebApi.Models;

namespace StudentWebApi.Application.MentorOperations.Commands.DeleteMentor
{
    public class DeleteMentorCommand
    {
        private readonly StudentDbContext _dbContext;
        public int Id { get; set; }
        public DeleteMentorCommand(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var mentor = _dbContext.Mentors.Where(x => x.MentorId == Id).SingleOrDefault();
            if (mentor == null)
                throw new InvalidOperationException("Silinecek mentör bulunamadı.");
            var project = _dbContext.Projects.Where(x => x.ProjectId == mentor.ProjectId).SingleOrDefault();
            if (project.IsActive == false)
            {
                _dbContext.Mentors.Remove(mentor);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Mentör silinemez. Silmek istediğiniz mentörün aktif projesi mevcut.");
            }
        }
    }
}
