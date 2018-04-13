using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private const string sessionKey = "students";

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return HttpContext.Session.Get<IEnumerable<Student>>(sessionKey);
        }

        [HttpPost]
        public void Post([FromBody]IEnumerable<Student> students)
        {
            HttpContext.Session.Set(sessionKey, students);
        }
    }
}