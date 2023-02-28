using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LessonsModel
    {
        public LessonsModel()
        {
        }
        public int LessonID { get; set; }
        public Nullable<int> CoursesID { get; set; }
        public Nullable<int> LessonNumber { get; set; }
        public Nullable<int> Mark { get; set; }
    }
}
