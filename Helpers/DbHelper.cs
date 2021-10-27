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
            return new SqlConnection(@"Data Source=fypdatacao.database.windows.net;Initial Catalog=CAOCHECK;User ID=sduggan;Password=Knockboy@2;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
    }
}


