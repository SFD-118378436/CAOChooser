using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Models
{
    public class Admin
    {
        public int AdminID { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string UserSalt { get; set; }

        public string ThirdLevelInstitution { get; set; }
    }
}
