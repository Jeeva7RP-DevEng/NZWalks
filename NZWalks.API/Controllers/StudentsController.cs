using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("{name}")]
        public IActionResult GetAllStudents(string name)
        {
            string[] students = new string[] { "john", "Ram", "ravi", "Emily", "David"};
            if(students.Contains(name))
            {
                return Ok(name);
            }
            return Ok(students);
        }
    }
}
