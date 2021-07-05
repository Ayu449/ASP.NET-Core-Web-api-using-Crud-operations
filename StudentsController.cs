using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class StudentsController : ControllerBase
    {

        [Route("api/get-all")]
        public string GetAll()
        {
            return "Hello from get all";
        }

        [Route("api/get-all-authors")]
        public string GetAllAuthors()
        {
            return "Hello from get all authors";
        }


         List<Student> _oStudents = new List<Student>()
        {
            new Student() {Id=1, Name="Ayush",Roll=1001},
            new Student() {Id=2, Name="Aman",Roll=1002},
            new Student() {Id=3, Name="Shivam",Roll=1003},
            new Student() {Id=4, Name="Ravi",Roll=1004},
            new Student() {Id=5, Name="Hemant",Roll=1005}
        };

        [Route("Student/Gets")]
        [HttpGet]
        public IActionResult Gets()
        {
            if (_oStudents.Count == 0)
            {
                return NotFound("No List Found.");
            }
            return Ok(_oStudents);
        }

        [HttpGet("GetStudent")]

        public IActionResult Get(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (oStudent == null)
            {
                return NotFound("No Student Found");
            }
            return Ok(oStudent);
        }

        [HttpPost]

        public IActionResult Save(Student oStudent)
        {
            _oStudents.Add(oStudent);
            if(_oStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }

        [HttpDelete]

        public IActionResult DeleteStudent(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x=>x.Id == id);
            if(oStudent == null)
            {
                return NotFound("No Student Found");
            }
            _oStudents.Remove(oStudent);

            if(_oStudents.Count == 0)
            {
                return NotFound("No List Found.");
            }
            return Ok(_oStudents);
        }



        [Route("Student/PutUpdate/{id}")]
        [HttpPut]
        public async Task<IActionResult> PutUpdate(int id, [FromBody] Student oStudent)
        {
            if (id != oStudent.Id)
            {
                return BadRequest("Id does not match");
            }

            var result = _oStudents.SingleOrDefault(x => x.Id == id);
            if (result != null && result.Name != oStudent.Name && result.Roll != oStudent.Roll)
            {
                result.Id = oStudent.Id;
                result.Name = oStudent.Name;
                result.Roll = oStudent.Roll;
                return Ok(_oStudents);
            }
            else
            {
                return BadRequest("wrong method");
            }
        }

        [Route("Student/PatchUpdate/{id}")]
        [HttpPatch]
        public async Task<IActionResult> PatchUpdate(int id, [FromBody] Student oStudent)
        {
            if (id != oStudent.Id)
            {
                return BadRequest("Id does not match");
            }

            var result = _oStudents.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Id = oStudent.Id;
                result.Name = oStudent.Name;
                result.Roll = oStudent.Roll;
                return Ok(_oStudents);
            }
            else
            {
                return BadRequest("wrong method");
            }
        }






    }
}
