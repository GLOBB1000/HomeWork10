using HomeWork10.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HomeWork10.Users
{
    public class Manager : User
    {
        public Manager(string login, string password, string u_type) : base(login, password, u_type)
        {
        }

        public override string Login { get; set; }
        public override string Password { get; set; }
        protected override string u_type { get; set; }
        protected override Client this_client { get; set; }

        public override void InitClient(Client client)
        {
            base.InitClient(client);
        }

        public void AddUser(ListBox listBox)
        {
            var newCl = new Client(this);
            this_client = newCl;
            listBox.Items.Add(newCl);
            SetClientInfo(newCl);
        }

        private void SetClientInfo(Client client)
        {
            if (ClientDB.Clients == null)
                ClientDB.Clients = new List<Client>();

            ClientDB.Clients.Add(client);

            new ClientDB().Save();
        }

        public override void Save(string phone, string name, string surname, string lastName, string seria, string number)
        {
            base.Save(phone, name, surname, lastName, seria, number);
        }
    }
}
