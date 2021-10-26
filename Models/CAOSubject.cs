using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Models
{
    public class CAOSubject
    {
        public int CourseID { get; set; }
        public String CourseName { get; set; }
        public String Description { get; set; }
        public int KeyWordCount { get; set; }
        public int Level { get; set; }
    }
}
