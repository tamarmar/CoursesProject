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
    [RoutePrefix("api/StudentInCourse")]
    public class StudentInCourseController : ApiController
    {
        BL.StudentInCourseBl studentInCourseBl = new BL.StudentInCourseBl();
        [AcceptVerbs("GET", "POST")]
        [Route("insertStudentInCourse")]
        [HttpPost]
        public bool InsertStudentInCourse(StudentInCourse studentInCourse)
        {
            return studentInCourseBl.InsertStudentInCourse(studentInCourse);
        }
        [Route("updatestudentincourse")]
        [HttpPost]
        public bool UpdateStudentInCourse(StudentInCourse studentincourse)
        {
            return studentInCourseBl.UpdateStudentInCourse(studentincourse);
        }
        [Route("deletestudentincourse")]
        [HttpPost]
        public bool DeleteStudentInCourse(StudentInCourse studentincourse)
        {
            return studentInCourseBl.DeleteStudentInCourse(studentincourse);
        }
        [Route("getstudentInCourse")]
        [HttpGet]
        public List<StudentInCourse> getStudentInCourse()
        {
            return studentInCourseBl.GetAllStudentInCourse();
        }

        [Route("getcoursesstnotex")]
        [HttpPost]
        public List<StudentInCourse> GetCoursesStNotEx(StudentInCourse studentincourse)
        {
            int n = studentincourse.StudentID.GetValueOrDefault();
            return studentInCourseBl.GetCoursesStNotEx(n);
        }
        [Route("GetStudentInCourseById")]
        [HttpPost]
        public List<StudentInCourse> GetStudentInCourseById(StudentInCourse studentincourse)
        {
            int n = studentincourse.StudentID.GetValueOrDefault();
            return studentInCourseBl.GetStudentInCourseById(n);
        }
        [Route("updatepoints")]
        [HttpPost]
        public void UpdatePoints(Student student, Lesson lesson, Cours course)
        {
            studentInCourseBl.UpdatePoints(student, lesson, course);
        }
        [Route("updatelessons")]
        [HttpPost]
        public void UpdateLesson(Student student, Lesson lesson, Cours course)
        {
            studentInCourseBl.UpdateLesson(student, lesson, course);
        }

    }
}
