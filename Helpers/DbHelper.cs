using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Helpers
{
    public class DbHelper
    {
        public static SqlConnection GetConnection() 
        {
            return new SqlConnection(@"Data Source = DESKTOP - 61OFRRH; Initial Catalog = CAO Check;");
        }
    }
}
