using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LessonsBl
    {
        DBConection dbCon = new DBConection();
        public LessonsBl()
        {
        }
        public List<Lesson> GetAllLessons()
        {
            List<Lesson> listOfLessons = dbCon.GetDbSet<Lesson>().ToList();
            return listOfLessons;
        }
        public bool InsertLesson(Lesson lesson)
        {
            try
            {
                if (GetAllLessons().Find(c => c.LessonID == lesson.LessonID) == null)
                {
                    dbCon.Execute<Lesson>(lesson, DBConection.ExecuteActions.Insert);
                }
                CoursesBl co = new CoursesBl();
                Cours cr=co.GetAllCourses().Find(x => x.CourseID == lesson.CoursesID);
                cr.NumOfLessons += 1;
                co.UpdateCourses(cr);
                return true;
                //return lesson.LessonID.ToString();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateLesson(Lesson lesson)
        {
            try
            {
                dbCon.Execute<Lesson>(lesson, DBConection.ExecuteActions.Update);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteLesson(Lesson lesson)
        {
            try
            {
                if (GetAllLessons().Find(c => c.LessonID == lesson.LessonID) != null)
                    dbCon.Execute<Lesson>(lesson, DBConection.ExecuteActions.Delete);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Lesson> GetLessonByCourseId(int courseid)
        {
            return GetAllLessons().FindAll(l => l.CoursesID == courseid);
        }
        
    }
}
