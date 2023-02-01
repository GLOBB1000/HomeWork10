using HomeWork10.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Users
{
    public abstract class User
    {
        public abstract string Login { get; set; }

        public abstract string Password { get; set; }

        protected abstract string u_type { get; set; }

        protected abstract Client this_client { get; set; }

        public virtual string U_Type
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

        public User(string login, string password, string u_type)
        {
            Login = login;
            Password = password;
            this.u_type = u_type;
        }

        public virtual void InitClient(Client client)
        {
            this_client = client;
        }

        public virtual void Save(string phone, string name, string surname, string lastName, string seria, string number)
        {
            if (this_client != null)
            {
                var client = ClientDB.Clients.Find(x => this_client.Id == x.Id);

                if (client != null)
                {
                    client.PhoneNumber = phone;
                    client.Name = name;
                    client.LastName = lastName;
                    client.SecondName = surname;

                    if (U_Type == "Manager")
                    {
                        client.DocDataSeries = seria;
                        client.DocDataNumber = number;
                    }

                    client.CheckData(this);
                }

                new ClientDB().Save();
            }
        }

        public abstract void ChangeClient(Client client);
    }
}
