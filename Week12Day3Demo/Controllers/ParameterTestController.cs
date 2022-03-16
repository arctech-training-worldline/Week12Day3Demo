using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week12Day3Demo.Models;

namespace Week12Day3Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterTestController : ControllerBase
    {
        [HttpGet("AddNumbers")]
        public int Get(int num1, int num2)
        {
            return num1 + num2;
        }

        [HttpPost("CheckStudentRollNo")]
        public bool CheckStudent(Student student)
        {
            if (student.RollNo < 100)
                return true;

            return false;
        }


        [HttpPost("GetStudent")]
        public Student GetStudent()
        {
            return new Student { RollNo = 101, Name = "Raman Gujral" };
        }


        [HttpPost("GetStudents")]
        public List<Student> GetStudentList()
        {
            return new List<Student> {
                new Student { RollNo = 101, Name = "Raman Gujral" },
                new Student { RollNo = 101, Name = "Naman Pujmal" }
            };
        }

        [HttpPost("GetStudents2")]
        public IEnumerable<Student> GetStudentIEnumerable()
        {
            return new List<Student> {
                new Student { RollNo = 101, Name = "Raman Gujral" },
                new Student { RollNo = 101, Name = "Naman Pujmal" }
            };
        }

        [HttpGet("GetMeSomething")]
        public IActionResult GetMeSomething(int value)
        {
            if (value < 10)
                return BadRequest();
            else if (value > 100)
                return NoContent();

            return Ok();
        }

        [HttpGet("GetMeANaughtyStudent")]
        public ActionResult<Student> GetAStudent(int rollNo)
        {
            if (rollNo > 0)
                return new Student { RollNo = rollNo, Name = "Something Something" };

            return BadRequest();
        }
    }
}
