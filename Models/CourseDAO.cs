using CAOSelect.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Models
{
    public class CourseDAO
    {
        
        public  List<CAOSubject>  getCourse()
        {
            using (var db = DbHelper.GetConnection())
            {
               return this.EditableItems = db.Query<CAOSubject>("SELECT * FROM CAOSUBJECT;").ToList();
            }
        }
        public List<CAOSubject> EditableItems { get; set; }
    }
}

