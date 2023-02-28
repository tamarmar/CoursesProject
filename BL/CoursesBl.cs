using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CoursesBl
    {
        DBConection dbCon = new DBConection();
        public CoursesBl()
        {
        }
        public List<Cours> GetAllCourses()
        {
            List<Cours> listOfCourses = dbCon.GetDbSet<Cours>().ToList();
            return listOfCourses;
        }
        public bool InsertCourse(Cours course)
        {
            try
            {
                if (GetAllCourses().Find(c => c.CourseID == course.CourseID) == null)
                {
                    dbCon.Execute<Cours>(course, DBConection.ExecuteActions.Insert);
                }
                return true;
                //return course.CourseID.ToString();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateCourses(Cours course)
        {
            try
            {
                if (GetAllCourses().Find(c => c.CourseID == course.CourseID) != null)
                    dbCon.Execute<Cours>(course, DBConection.ExecuteActions.Update);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCourses(Cours course)
        {
            try
            {
                if (GetAllCourses().Find(c => c.CourseID == course.CourseID) != null)
                    dbCon.Execute<Cours>(course, DBConection.ExecuteActions.Delete);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Cours> CoursesByStId(int studentid)
        {
            StudentInCourseBl s = new StudentInCourseBl();
            List<StudentInCourse> allstudentsInCourses = s.GetAllStudentInCourse();
            List<Cours> courses = GetAllCourses();
            
           // return GetAllCourses().FindAll(c => allstudentsInCourses.Any(st=> st.CoursesID == c.CourseID && st.StudentID == studentid));

            List<Cours> lstCoursesOfStudent = (from stdInCourse in allstudentsInCourses
                                              join course in courses on stdInCourse.CoursesID equals course.CourseID
                                              where stdInCourse.StudentID == studentid
                                              select course).ToList();
            return lstCoursesOfStudent;
        }
        public List<Cours> CoursesNotStId(int studentid)
        {
            StudentInCourseBl s = new StudentInCourseBl();
            List<StudentInCourse> allstudentsInCourses = s.GetAllStudentInCourse();
            return GetAllCourses().FindAll(c => allstudentsInCourses.Any(st=> st.CoursesID == c.CourseID && st.StudentID != studentid));

        }

    }
}
