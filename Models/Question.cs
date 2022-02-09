using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public String SourceQuestion { get; set; }
        public String InterestArea { get; set; }

        public String PsyTestID { get; set; }
    }
}
