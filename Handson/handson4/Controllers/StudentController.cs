using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using handson4.Model;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace handson4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private static List<Student> _students = new List<Student>();
        // GET: api/Students
        [HttpGet(Name ="GetAllStudent")]
        public IActionResult Get()
        {
            return new ObjectResult(_students);
        }

        // GET api/Student/5
        [HttpGet("{id}", Name ="GetStudent")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(_students.FirstOrDefault(p => p.Id == id));
        }

        // POST api/student
        [HttpPost(Name ="CreateStudent")]
        public IActionResult Post([FromBody] Student student)
        {
            _students.Add(student);
            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}", Name ="UpdateStudent")]
        public IActionResult Put(int id, [FromBody]Student student)
        {
            _students.FirstOrDefault(p => p.Id == id).Name = student.Name;
            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}",Name ="DeleteStudent")]
        public IActionResult Delete(int id)
        {
            var _student=_students.FirstOrDefault(p => p.Id == id);
            _students.Remove(_student);
            return new NoContentResult();
        }
    }
}
