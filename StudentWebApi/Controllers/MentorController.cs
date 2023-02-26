using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Application.MentorOperations.Commands.CreateMentor;
using StudentWebApi.Application.MentorOperations.Commands.DeleteMentor;
using StudentWebApi.Application.MentorOperations.Commands.UpdateMentor;
using StudentWebApi.Application.MentorOperations.Queries.GetMentorDetail;
//using StudentWebApi.Application.MentorOperations.Commands.DeleteMentor;
//using StudentWebApi.Application.MentorOperations.Commands.UpdateMentor;
using StudentWebApi.Application.MentorOperations.Queries.GetMentors;
//using StudentWebApi.Application.MentorOperations.Queries.GetMentorDetail;
using StudentWebApi.Models;

namespace StudentWebApi.Controllers
{
    [Authorize]
    [Route("[controller]s")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly StudentDbContext _context;
        private readonly IMapper _mapper;

        public MentorController(StudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMentor([FromBody] CreateMentorViewModel newMentor)
        {
            CreateMentorCommand command = new CreateMentorCommand(_context, _mapper);
            command.Model = newMentor;
            CreateMentorCommandValidator validator = new CreateMentorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetMentorsList()
        {
            GetMentorsQuery query = new GetMentorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMentorbyId(int id)
        {
            MentorDetailViewModel result;
            try
            {
                GetMentorDetailQuery query = new GetMentorDetailQuery(_context, _mapper);
                query.Id = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteStudent([FromQuery] int id)
        {
            DeleteMentorCommand command = new DeleteMentorCommand(_context);
            command.Id = id;
            DeleteMentorCommandValidator validator = new DeleteMentorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMentor(int id, [FromBody] UpdateMentorViewModel updatedMentor)
        {
            try
            {
                UpdateMentorCommand command = new UpdateMentorCommand(_context);
                command.Id = id;
                command.Model = updatedMentor;
                UpdateMentorCommandValidator validator = new UpdateMentorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
