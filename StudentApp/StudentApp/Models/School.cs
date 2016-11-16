using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentApp.Models
{
    public class School
    {

        [DisplayName("Student")]
        public Student SI { get; set; }

        [DisplayName("Course")]
        public Cours CI { get; set; }

        


        SchoolAppEntities1 db = new SchoolAppEntities1();

    }
}