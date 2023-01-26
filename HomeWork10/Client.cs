using HomeWork10.DataBases;
using HomeWork10.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
    public class Client: ITimeCheck
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
        public Client(Consultant consultant)
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

            if(consultant != null)
                UserType = consultant.UserType;
        }

        public void CheckData(Consultant consultant)
        {
            if (CheckDate != DateTime.Now)
                CheckDate = DateTime.Now;

            UserType = consultant.UserType;
        }
    }
}
