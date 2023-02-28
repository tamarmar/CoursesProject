using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CoursesModel
    {
        public CoursesModel()
        {
        }

        public int CourseID { get; set; }
        public string CoursesName { get; set; }
        public Nullable<int> Difficulty { get; set; }
        public Nullable<int> NumOfLessons { get; set; }
    }
}
