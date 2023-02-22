using StudentWebApi.Models;

namespace StudentWebApi.Application.ProjectOperations.Commands.CreateProject
{
    public class CreateProjectCommand
    {
        public CreateProjectViewModel Model { get; set; }
        private readonly IStudentDbContext _context;

        public CreateProjectCommand(IStudentDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var project = _context.Projects.SingleOrDefault(x => x.Name == Model.ProjectName);
            if (project != null)
                throw new InvalidOperationException("Aynı proje ikinci kez kaydedilemez!");
            project = new Project();
            project.Name = Model.ProjectName;
            _context.Projects.Add(project);
            _context.SaveChanges();
        }
    }

    public class CreateProjectViewModel
    {
        public string ProjectName { get; set; }
    }
}
