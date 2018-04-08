using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        [HttpGet]
        [EnableCors("AllowAll")]
        public IEnumerable<Student> Get()
        {
            return Program.Students;
        }

        [HttpPost]
        [EnableCors("AllowAll")]
        public void Post([FromBody]IEnumerable<Student> students)
        {
            Program.Students = students.ToList();
        }
    }
}