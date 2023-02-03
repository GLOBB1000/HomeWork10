using HomeWork10.DataBases;
using HomeWork10.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork10
{
    public class Client: ITimeCheck, IComparable<Client>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }

        public string PhoneNumber { get; set; }

        public string DocDataSeries { get; set; }
        public string DocDataNumber { get; set; }
        public DateTime CheckDate { get; set; }
        public string UserType { get; set; }

        //Добавил время изменения данных и кто менял данные, просто не совсем понимаю что значит тип изменения данных и какие данные были изменены и куда это записывать
        public Client(User user)
        {
            Id = new Random().Next(0, 9999999);

            if(ClientDB.Clients == null)
                ClientDB.Clients = new List<Client>();

            while(ClientDB.Clients.Exists(x => x.Id == Id))
                Id = new Random().Next(0, 9999999);

            Name = "Test";
            LastName = "Test sur";
            SecondName = "Test second";

            PhoneNumber = "+79123474321";

            DocDataSeries = "9231";
            DocDataNumber = "232543";

            CheckDate = DateTime.Now;

            if(user != null)
                UserType = user.U_Type;
        }

        public void CheckData(User user)
        {
            if (CheckDate != DateTime.Now)
                CheckDate = DateTime.Now;

            UserType = user.U_Type;
        }

        public int CompareTo(Client? other)
        {
            if (other == null)
                return 0;

            if (other.Name.First() > this.Name.First())
                return -1;
            else if (other.Name.First() < this.Name.First())
                return 1;
            else
                return 0;
        }
    }
}
