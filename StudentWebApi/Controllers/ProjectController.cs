using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Application.ProjectOperations.Commands.CreateProject;
using StudentWebApi.Application.ProjectOperations.Commands.DeleteProject;
using StudentWebApi.Application.ProjectOperations.Commands.UpdateProject;
using StudentWebApi.Application.ProjectOperations.Queries;
using StudentWebApi.Application.ProjectOperations.Queries.GetProjectDetail;
using StudentWebApi.Models;
using static StudentWebApi.Application.ProjectOperations.Commands.UpdateProject.UpdateProjectCommand;

namespace StudentWebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IStudentDbContext _context;
        private readonly IMapper _mapper;

        public ProjectController(IStudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            GetProjectsQuery query = new GetProjectsQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectbyId(int id)
        {
            GetProjectDetailQuery query = new GetProjectDetailQuery(_context, _mapper);
            query.QueryId = id;
            GetProjectDetailQueryValidator validator = new GetProjectDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var obj = query.Handle();
            
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] CreateProjectViewModel newProject)
        {
            CreateProjectCommand command = new CreateProjectCommand(_context);
            command.Model = newProject;
            CreateProjectCommandValidator validator = new CreateProjectCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, [FromBody] UpdateProjectViewModel updatedProject)
        {
            UpdateProjectCommand command = new UpdateProjectCommand(_context);
            command.Id = id;
            command.Model = updatedProject;
            UpdateProjectCommandValidator validator = new UpdateProjectCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProject([FromQuery] int id)
        {
            DeleteProjectCommand command = new DeleteProjectCommand(_context);
            command.Id = id;
            DeleteProjectCommandValidator validator = new DeleteProjectCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}
