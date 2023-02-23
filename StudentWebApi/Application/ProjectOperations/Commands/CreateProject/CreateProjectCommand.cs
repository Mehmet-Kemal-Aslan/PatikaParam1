using StudentWebApi.Models;

namespace StudentWebApi.Application.ProjectOperations.Commands.CreateProject
{
    public class CreateProjectCommand
    {
        public CreateProjectViewModel Model { get; set; }
        private readonly StudentDbContext _context;

        public CreateProjectCommand(StudentDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var project = _context.Projects.SingleOrDefault(x => x.Name == Model.ProjectName);
            if (project != null)
                throw new InvalidOperationException("Proje zaten mevcut.");
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
