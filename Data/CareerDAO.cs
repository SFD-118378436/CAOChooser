using CAOSelect.Helpers;
using CAOSelect.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Data
{
    public class CareerDAO
    {

        public List<Career> getCareers()
        {
            // code found at https://ucc.instructure.com/courses/39791/files/4107181?module_item_id=1199745
            //Getting db connection used before
            using (var db = DbHelper.GetConnection())
            {
                //creating a list 
                return this.EditableItems = db.Query<Career>("SELECT * FROM Career;").ToList();
            }
        }


        public List<Career> getCareersByInterestArea(string ia)
        {
            // code found at https://ucc.instructure.com/courses/39791/files/4107181?module_item_id=1199745
            //Getting db connection used before
            using (var db = DbHelper.GetConnection())
            {
                //creating a list 
                return this.EditableItems = db.Query<Career>("SELECT * FROM Career WHERE InterestArea ='" + ia + "';").ToList();
            }
        }

        public List<Career> EditableItems { get; set; }
    }
}
