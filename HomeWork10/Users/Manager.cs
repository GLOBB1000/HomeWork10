using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Users
{
    public class Manager : Consultant
    {
        public Manager(string login, string pass, string user_type) : base(login, pass, user_type)
        {

        }
    }
}
