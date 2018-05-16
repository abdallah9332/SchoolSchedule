using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _123.Models
{
    public class CourseViewModel
    {
        public int Course_ID { get; set; }
        public Nullable<int> Teacher_ID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public Nullable<int> WhichYear { get; set; }
        public int WhichSemester { get; set; }
        public Nullable<int> NumberOfStudent { get; set; }
        public string TypeOfLesson { get; set; }
        public string TeacherName { get; set; }




    }
}