using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentInCourseModel
    {

        public StudentInCourseModel()
        {

        }
        public int ID { get; set; }
        public Nullable<int> CoursesID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> CurrentLesson { get; set; }
        public Nullable<int> points { get; set; }
    }
}
