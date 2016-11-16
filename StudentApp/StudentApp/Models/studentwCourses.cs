using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentApp.Models
{
    public class studentwCourses
    {
        [DisplayName("Course")]
        public List<Cours> CID { get; set; }

        [DisplayName("Students")]
        public Student SID { get; set; }
    }
}