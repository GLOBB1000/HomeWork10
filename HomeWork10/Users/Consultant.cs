using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Users
{
    public class Consultant: User
    {
        public Consultant(string login, string password, string u_type) : base(login, password, u_type)
        {
        }

        public override string Login { get; set; }
        public override string Password { get; set; }
        protected override string u_type { get; set; }

        public override string U_Type { get => base.U_Type; set => base.U_Type = value; }
        protected override Client this_client { get; set; }

        public override void InitClient(Client client)
        {
            base.InitClient(client);
        }

        public override void ChangeClient(Client client)
        {
            throw new NotImplementedException();
        }

        public override void Save(string phone, string name, string surname, string lastName, string seria, string number)
        {
            base.Save(phone, name, surname, lastName, seria, number);
        }
    }
}
