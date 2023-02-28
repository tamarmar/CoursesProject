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
    [RoutePrefix("api/Lessons")]
    public class LessonsController : ApiController
    {
        BL.LessonsBl lessonsBl = new BL.LessonsBl();
        [AcceptVerbs("GET", "POST")]
        [Route("insertLesson")]
        [HttpPost]
        public bool InsertLesson(Lesson lesson)
        {
            
            return lessonsBl.InsertLesson(lesson);
        }
        [Route("updatelesson")]
        [HttpPost]
        public bool UpdateLesson(Lesson lesson)
        {
            return lessonsBl.UpdateLesson(lesson);
        }
        [Route("deletelesson")]
        [HttpPost]
        public bool DeleteLesson(Lesson lesson)
        {
            return lessonsBl.DeleteLesson(lesson);
        }
        [Route("getlessons")]
        [HttpGet]
        public List<Lesson> GetLessons()
        {
            return lessonsBl.GetAllLessons();
        }
        [Route("getlessonbycourseid")]
        [HttpPost]
        public List<Lesson> GetLessonsByCourseId(Cours course)
        {
            return lessonsBl.GetLessonByCourseId(course.CourseID);
        }
    }
}
