using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentApp.Models
{
    public class CourseInfo
    {
        [DisplayName("Course")]
        public List <Cours> CI { get; set; }

    }
}