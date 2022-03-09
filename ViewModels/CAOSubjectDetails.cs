using CAOSelect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.ViewModels
{
    public class CAOSubjectDetails
    { 
        public CAOSubject Course { get; set; }
        public List<RequiredSubject> ReqSubjects { get; set; }
    }
}
