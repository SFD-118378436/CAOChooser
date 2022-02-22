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

        //Code used to gather ratios
        [Display(Name = "Creative Ratio")]
        public int creative { get; set; }

        [Display(Name = "Problem Solving Ratio")]
        public int problemsolving { get; set; }

        [Display(Name = "Analytical Ratio")]
        public int analytical { get; set; }

        [Display(Name = "Interpersonal Ratio")]
        public int interpersonal { get; set; }
    }
}
