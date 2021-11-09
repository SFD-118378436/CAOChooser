using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Helpers
{
    public class DbHelper
    {   //using code from https://ucc.instructure.com/courses/39791/files/4107181?module_item_id=1199745
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(@"Server=tcp:fypdatacao.database.windows.net,1433;Initial Catalog=CAOCHECK;Persist Security Info=False;User ID=sduggan;Password=Knockboy@2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
    }
}


