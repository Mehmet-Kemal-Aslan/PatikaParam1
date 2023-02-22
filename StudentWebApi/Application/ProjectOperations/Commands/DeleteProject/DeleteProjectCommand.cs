using StudentWebApi.Models;

namespace StudentWebApi.Application.ProjectOperations.Commands.DeleteProject
{
    public class DeleteProjectCommand
    {
        private readonly IStudentDbContext _context;
        public int Id { get; set; }
        public DeleteProjectCommand(IStudentDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var project = _context.Projects.Where(x => x.ProjectId == Id).SingleOrDefault();
            if (project == null)
                throw new InvalidOperationException("Silinecek proje bulunamadı.");
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}
