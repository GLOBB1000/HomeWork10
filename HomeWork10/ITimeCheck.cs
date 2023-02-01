using HomeWork10.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
    interface ITimeCheck
    {
        public DateTime CheckDate { get; set; }

        public string UserType { get; set; }

        public abstract void CheckData(User user);
    }
}
