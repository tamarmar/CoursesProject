using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StudentInCourseBl
    {
        DBConection dbCon = new DBConection();
        public StudentInCourseBl()
        {
        }
        public List<StudentInCourse> GetAllStudentInCourse()
        {
            List<StudentInCourse> listOfStudentInCourse = dbCon.GetDbSet<StudentInCourse>().ToList();
            return listOfStudentInCourse;
        }
        public bool InsertStudentInCourse(StudentInCourse studentInCourse)
        {
            try
            {
                if (GetAllStudentInCourse().Find(c => c.ID == studentInCourse.ID) == null)
                {
                    dbCon.Execute<StudentInCourse>(studentInCourse, DBConection.ExecuteActions.Insert);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateStudentInCourse(StudentInCourse studentInCourse)
        {
            try
            {
                dbCon.Execute<StudentInCourse>(studentInCourse, DBConection.ExecuteActions.Update);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteStudentInCourse(StudentInCourse studentInCourse)
        {
            try
            {
                if (GetAllStudentInCourse().Find(c => c.ID == studentInCourse.ID) != null)
                    dbCon.Execute<StudentInCourse>(studentInCourse, DBConection.ExecuteActions.Delete);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<StudentInCourse> GetCoursesStNotEx(int studentid)
        {
            return GetAllStudentInCourse().FindAll(c => c.StudentID != studentid);
        }
        public List<StudentInCourse> GetStudentInCourseById(int studentid)
        {
            return GetAllStudentInCourse().FindAll(c => c.StudentID == studentid);
        }
        public void UpdatePoints(Student student, Lesson lesson, Cours course)
        {
            StudentInCourse s = GetAllStudentInCourse().Find(c => c.CoursesID == course.CourseID && c.StudentID == student.StudentID);
            s.points += lesson.Mark;
            UpdateStudentInCourse(s);
        }
        public void UpdateLesson(Student student, Lesson lesson, Cours course)
        {
            StudentInCourse s = GetAllStudentInCourse().Find(c => c.CoursesID == course.CourseID && c.StudentID == student.StudentID);
            s.CurrentLesson = lesson.LessonNumber;
            UpdateStudentInCourse(s);
        }
    }
}
