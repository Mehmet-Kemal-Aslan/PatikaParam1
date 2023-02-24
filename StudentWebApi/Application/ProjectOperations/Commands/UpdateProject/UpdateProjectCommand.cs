using StudentWebApi.Models;

namespace StudentWebApi.Application.ProjectOperations.Commands.UpdateProject
{
    public class UpdateProjectCommand
    {
        private readonly StudentDbContext _context;
        public int Id { get; set; }
        public UpdateProjectViewModel Model { get; set; }
        public UpdateProjectCommand(StudentDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var project = _context.Projects.Where(x => x.ProjectId == Id).SingleOrDefault();
            if (project == null)
                throw new InvalidOperationException("Güncellenecek proje bulunamadı.");

            if (_context.Projects.Any(x => x.Name.ToLower() == Model.Name.ToLower())) //&& x.ProjectId == Id))
                throw new InvalidOperationException("Aynı isimli bir proje zaten mevcut.");

            project.Name = String.IsNullOrEmpty(Model.Name.Trim()) ? project.Name : Model.Name;
            project.IsActive = Model.IsActive;
            _context.SaveChanges();
        }

        public class UpdateProjectViewModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; } = true;
        }
    }
}
