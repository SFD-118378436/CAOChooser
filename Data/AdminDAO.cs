using CAOSelect.Helpers;
using CAOSelect.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Data
{
    public class AdminDAO
    {
        public List<Admin> getAdmins()
        {
            // code found at https://ucc.instructure.com/courses/39791/files/4107181?module_item_id=1199745
            //Getting db connection used before
            using (var db = DbHelper.GetConnection())
            {
                //creating a list 
                return this.EditableItems = db.Query<Admin>("SELECT * FROM Admin;").ToList();
            }
        }
        public List<Admin> EditableItems { get; set; }

        public void insertAdmin(Admin admin)
        {
            using(var db = DbHelper.GetConnection())
            {
                string query = "INSERT INTO Admin(Username,PasswordHash,UserSalt,ThirdLevelInstitution) VALUES('" + admin.Username + "','" + admin.PasswordHash + "','" + admin.UserSalt + "','" + admin.ThirdLevelInstitution + "');";

                db.Query(query);
            }
        }   

        public Admin getAdminbyUsername(string username)
        {
            using (var db = DbHelper.GetConnection())
            {
                //creating a query to find by name 
                 this.EditableItems = db.Query<Admin>("SELECT * FROM Admin WHERE Username ='" + username +"';").ToList();
                return EditableItems[0];

            }
        }
    }
}
