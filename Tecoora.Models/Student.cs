using System;
using System.Collections.Generic;
using System.Text;

namespace Tecoora.Models
{
    // tools => nuget package manager console => package manager console
    // add-migration test1
    // update-database
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


    }
}
