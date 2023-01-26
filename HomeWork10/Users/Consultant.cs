using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Users
{
    public class Consultant
    {
        public string Login { get; set; }

        public string Password { get; set; }

        private string u_type;

        public string UserType
        {
            get
            {
                return u_type;
            }
            set
            {
                u_type = value;
            }
        }

        public Consultant(string login, string pass, string user_type)
        {
            Login = login;
            Password = pass;
            UserType = user_type;
        }
    }
}
