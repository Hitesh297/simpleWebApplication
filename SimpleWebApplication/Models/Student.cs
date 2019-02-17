using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebApplication.Models
{
    public class Student
    {
        public virtual int RollNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string Subject { get; set; }
    }
}