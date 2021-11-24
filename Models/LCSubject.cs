using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Models
{
    public class LCSubject
    {
        public int SubjectID { get; set; }

        public String SubjectName { get; set; }
    }

    public class LCSubjectList
    {
   

        public LCSubjectList(string subject, string level)
        {
            this.SubjectName = subject;
            this.Level = level;
        }

        public String SubjectName { get; set; }
        public String Level { get; set; }
    }
}

