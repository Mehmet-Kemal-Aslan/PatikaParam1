using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;
using StudentWebApi.Extension;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILesson _lessonService;
        public LessonController(ILesson lessonService)
        {
            _lessonService = lessonService;
        }

        //Gets lesson list.
        [HttpGet]
        public IEnumerable<Lesson> GetEmployeeList1()
        {
            var res = _lessonService.GetLesson();
            return res;
        }


        // Uses the firstLetter extension to warn the user.
        [HttpGet("{id}")]
        public IActionResult daysToNextSession(int id)
        {
            var lesson = _lessonService.GetLesson().Where(student => student.Id == id).SingleOrDefault();
            string letter = lesson.Name;
            string result = letter.firstLetter();
            if (result == "Attantion! The first letter is lowercase.")
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
