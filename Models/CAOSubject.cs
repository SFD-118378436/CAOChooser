using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Models
{
    public class CAOSubject
    {

        [Display(Name = "CourseID")]
        public String CourseID { get; set; }

        [Display(Name = "Course name:")]
        public String CourseName { get; set; }

        [Display(Name = "Course Description:")]
        public String CourseDescription { get; set; }
        public int KeyWordCount { get; set; }

        [Display(Name = "Level")]
        public int Level { get; set; }

        [Display(Name = "Third Level Institute:")]
        public String ThirdLevelInstitute { get; set; }

        //Code used to gatehr ratios
        public int creative { get; set; }
        public int problemsolving { get; set; }
        public int analytical { get; set; }
        public int interpersonal { get; set; }
    }
}
