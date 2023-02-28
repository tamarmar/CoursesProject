using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        BL.CoursesBl courseBl = new BL.CoursesBl();
        [AcceptVerbs("GET", "POST")]
        [Route("insertCourse")]
        [HttpPost]
        public bool InsertCourse(Cours course)
        {
            return courseBl.InsertCourse(course);
        }
        [Route("updatecourse")]
        [HttpPost]
        public bool UpdateCourse(Cours course)
        {
            return courseBl.UpdateCourses(course);
        }
        [Route("deletecourse")]
        [HttpPost]
        public bool DeleteCourse(Cours course)
        {
            return courseBl.DeleteCourses(course);
        }
        [Route("getCourses")]
        [HttpGet]
        public List<Cours> GetCourses()
        {
            return courseBl.GetAllCourses();
        }
        [Route("get_courses_by_studentid")]
        [HttpPost]
        public List<Cours> GetCoursesByStId(Student student)
        {
            return courseBl.CoursesByStId(student.StudentID);
        }
        [Route("courses_not_studentid")]
        [HttpPost]
        public List<Cours> CoursesNotStId(Student student)
        {
            return courseBl.CoursesNotStId(student.StudentID);
        }
    }
}
