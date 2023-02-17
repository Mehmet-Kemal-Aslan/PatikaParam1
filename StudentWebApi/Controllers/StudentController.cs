using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;
using StudentWebApi.Operations;
using StudentWebApi.Operations.CreateStudents;
using StudentWebApi.Operations.DeleteStudent;
using StudentWebApi.Operations.GetStudentDetail;
using StudentWebApi.Operations.UpdateStudent;
using static StudentWebApi.Operations.CreateStudents.CreateStudentsCommand;
using static StudentWebApi.Operations.GetStudentDetail.GetStudentDetailQuery;
using static StudentWebApi.Operations.UpdateStudent.UpdateStudentCommand;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Üzerinde çalışmak için veri seti
        private static List<Student> StudentList = new List<Student>()
        {
            new Student
            {
                Id = 1,
                Name = "Mehmet Kemal",
                Surname = "Aslan",
                Grade = 6
            },
            new Student
            {
                Id = 2,
                Name = "Arif Cemal",
                Surname = "Özcan",
                Grade = 9
            },
            new Student
            {
                Id = 3,
                Name = "Sefa",
                Surname = "Çaksu",
                Grade = 10
            }
        };

        private readonly StudentDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(StudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Gets all records
        [HttpGet]
        public IActionResult GetStundentList()
        {
            GetStudentsQuery query = new GetStudentsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        // Gets one record by id
        [HttpGet("{id}")]
        public IActionResult GetStundentbyId(int id)
        {
            StudentDetailViewModel result;
            try
            {
                GetStudentDetailQuery query = new GetStudentDetailQuery(_context, _mapper);
                query.StudentId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        // posts a new record -- [FromBody]
        [HttpPost]
        public IActionResult AddStudent([FromBody] CreateStudentModel newStudent)
        {
            CreateStudentsCommand command = new CreateStudentsCommand(_context, _mapper);
            try
            {
                command.Model = newStudent;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // updates a record by id -- [FromBody]
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentUpdateViewModel updatedStudent)
        {
            try
            {
                UpdateStudentCommand command = new UpdateStudentCommand(_context);
                command.StudentId = id;
                command.Model = updatedStudent;
                UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // Deletes a record by id -- [FromQuery]
        [HttpDelete]
        public IActionResult DeleteStudent([FromQuery] int id)
        {
            try 
            {
                DeleteStudentCommand command = new DeleteStudentCommand(_context);
                command.StudentId = id;
                DeleteStudentCommandValidator validator = new DeleteStudentCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // Updates name of a record by id -- [FromBody]
        [HttpPatch("{id}")]
        public IActionResult UpdateStudentName(int id, [FromBody] string name)
        {
            var student = StudentList.SingleOrDefault(student => student.Id == id);
            if (student is null)
                return BadRequest();
            student.Name = name != default ? name : student.Name;
            return Ok();
        }

        // Filters records by name
        [HttpGet("filter")]
        public ActionResult<List<Student>> GetByName([FromQuery] string Name)
        {
            var filteredStudents = StudentList.FindAll(student => student.Name.Contains(Name));
            return Ok(filteredStudents);
        }

        [HttpGet("orderby/{Column}")]
        public ActionResult SortStudents(string Column)
        {
            var studentList = StudentList;
            if (Column == "Id")
            {
                studentList = StudentList.OrderBy(x => x.Id).ToList<Student>();
                return Ok(studentList);
            }
            else if (Column == "Name")
            {
                studentList = StudentList.OrderBy(x => x.Name).ToList<Student>();
                return Ok(studentList);
            }
            else
            {
                return BadRequest("Yanlış sıralama tercihleri yapılıdı.");
            }
        }
    }
}
