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
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {
        BL.StudentsBl studentsBl = new BL.StudentsBl();
        [AcceptVerbs("GET", "POST")]
        [Route("insertStudent")]
        [HttpPost]
        public bool InsertStudent(Student student)
        {
            return studentsBl.InsertStudent(student);
        }
        [Route("updatestudent")]
        [HttpPost]
        public bool UpdateStudent(Student student)
        {
            return studentsBl.UpdateStudent(student);
        }
        [Route("deletestudent")]
        [HttpPost]
        public bool DeleteStudent(Student student)
        {
            return studentsBl.DeleteStudent(student);
        }
        [Route("getstudents")]
        [HttpGet]
        public List<Student> getStudents()
        {
            return studentsBl.GetAllStudents();
        }
        [Route("studentexist")]
        [HttpPost]
        public bool StudentExist(Student student)
        {
            return studentsBl.StudentExist(student.StudentID);
        }
        [Route("GetStudentById")]
        [HttpPost]
        public Student GetStudentById(Student student)
        {
            return studentsBl.GetStudentById(student.StudentID);
        }
    }
}