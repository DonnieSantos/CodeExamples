using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var students = new List<Student>();
            students.Add(new Student() {
                ID = 123,
                Name = "Donnie"
            });
            return students;
        }

        [HttpPost]
        public void Post([FromBody]IEnumerable<Student> students)
        {
        }
    }
}