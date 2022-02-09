using CAOSelect.Helpers;
using CAOSelect.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Data
{
    public class QuestionDAO
    {

        public List<Question> getQuestions()
        {
            // code found at https://ucc.instructure.com/courses/39791/files/4107181?module_item_id=1199745
            //Getting db connection used before
            using (var db = DbHelper.GetConnection())
            {
                //creating a list 
                return this.EditableItems = db.Query<Question>("SELECT * FROM QUESTION;").ToList();
            }
        }
        public List<Question> EditableItems { get; set; }

        //Creating a method to just get Interests from DAO
        public List<String> getInterests()
        {
            using (var db = DbHelper.GetConnection())
            {
                //creating a list 
                return db.Query<String>("SELECT DISTINCT InterestArea FROM QUESTION;").ToList();
            }
        }

        //Getting the unique Questions by Interest Area
        public List<Question> getQuestionsByInterestArea(String interestArea)
        {
            
                using (var db = DbHelper.GetConnection())
                {
                    //creating a list 
                    return this.EditableItems = db.Query<Question>("SELECT * FROM QUESTION WHERE InterestArea ="+ interestArea + ";").ToList();
                }
            
        }
    }

    
}
