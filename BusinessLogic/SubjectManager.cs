using CAOSelect.Data;
using CAOSelect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.BusinessLogic
{
    public class SubjectManager
    {
        SubjectDAO subjectData = new SubjectDAO();

        public LCSubject getSubjectbyID(int subjectID)
        {
            List<LCSubject> courses = subjectData.getSubjects();

            LCSubject subject = new LCSubject();

            foreach (var c in courses)
            {
                if (c.SubjectID == subjectID)
                {
                    subject = c;
                }
            }

            return subject;
        }

        public LCSubject getSubjectbyName(String subjectName)
        {
            List<LCSubject> courses = subjectData.getSubjects();

            LCSubject subject = new LCSubject();

            foreach (var c in courses)
            {
                if (c.SubjectName == subjectName)
                {
                    subject = c;
                }
            }

            return subject;
        }
    }
}
