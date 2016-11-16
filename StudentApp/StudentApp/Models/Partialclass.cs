using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentApp
{
  
        [MetadataType(typeof(StudentMetaData))]
        public partial class Student
        {

        }
        
            public class StudentMetaData
        {
            [DisplayName("Student ID")]
            public int Id { get; set; }
            [DisplayName("Student Name")]
            public string StudentName { get; set; }
        }

    [MetadataType(typeof(CoursMetaData))]
    public partial class Cours
    {

    }
    public class CoursMetaData
    {
        [DisplayName("Courses ID")]
        public int ID { get; set; }
        [DisplayName("Course Names")]
        public string CourseName { get; set; }
        [DisplayName("Course Descriptions")]
        public string CourseDesc { get; set; }
    }

}
