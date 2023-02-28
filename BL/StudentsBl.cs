using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StudentsBl
    {
        DBConection dbCon = new DBConection();
        public StudentsBl()
        {
        }
        public List<Student> GetAllStudents()
        {
            List<Student> listOfStudents = dbCon.GetDbSet<Student>().ToList();
            return listOfStudents;
        }
        public bool InsertStudent(Student student)
        {
            try
            {
                if (GetAllStudents().Find(c => c.StudentID == student.StudentID) == null)
                {
                    dbCon.Execute<Student>(student, DBConection.ExecuteActions.Insert);
                }

                return true;
                //return student.StudentID.ToString();
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool UpdateStudent(Student student)
        {
            try
            {
                dbCon.Execute<Student>(student, DBConection.ExecuteActions.Update);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteStudent(Student student)
        {
            try
            {
                if (GetAllStudents().Find(c => c.StudentID == student.StudentID) != null)
                    dbCon.Execute<Student>(student, DBConection.ExecuteActions.Delete);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool StudentExist(int id)
        {
            if (GetAllStudents().Find(c => c.StudentID == id) != null)
                return true;
            return false;
        }
    }
}
