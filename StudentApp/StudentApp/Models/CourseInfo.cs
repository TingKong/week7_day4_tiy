using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentApp.Models
{
    public class CourseInfo
    {
        //[DisplayName("Course")]
        //public List <Cours> CI { get; set; }

        [DisplayName("Course")]
        public Cours CID { get; set; }

        [DisplayName("Students")]
        public List<Student>  SID { get; set; }

    }
}