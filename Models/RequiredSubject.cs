using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Models
{
    public class RequiredSubject
    {
        //Course with the Required Subject
        public CAOSubject course { get; set; }

        //Required LC Subject
        public LCSubject subject { get; set; }

        //Required Level
        public String Level { get; set; }
    }

}
