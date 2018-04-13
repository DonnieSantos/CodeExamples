using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        public static string SESSION_KEY = "TEST";

        [HttpGet]
        [EnableCors("AllowAll")]
        public IEnumerable<Student> Get()
        {
            IEnumerable<Student> students = HttpContext.Session.Get<IEnumerable<Student>>(SESSION_KEY);
            return students;
        }

        [HttpPost]
        [EnableCors("AllowAll")]
        public void Post([FromBody]IEnumerable<Student> students)
        {
            HttpContext.Session.Set(SESSION_KEY, students);
        }
    }
}

//[HttpGet("{id}")]
//[EnableCors("AllowAll")]
//public Student Get(int id)
//{
//    return Program.Students[id];
//}