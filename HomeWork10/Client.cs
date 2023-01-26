using HomeWork10.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }

        public string PhoneNumber { get; set; }

        public string DocDataSeries { get; private set; }
        public string DocDataNumber { get; private set; }


        public Client()
        {
            Id = new Random().Next(0, 9999999);

            if(ClientDB.Clients == null)
                ClientDB.Clients = new List<Client>();

            while(ClientDB.Clients.Exists(x => x.Id == Id))
                Id = new Random().Next(0, 19999);

            Name = "Test";
            LastName = "Test sur";
            SecondName = "Test second";

            PhoneNumber = "+79123474321";

            DocDataSeries = "9231";
            DocDataNumber = "232543";
        }

        public Client(string name, string lastName, string secondName, string phoneNumber, string docDataSeries, string docDataNumber)
        {
            Name = name;
            LastName = lastName;
            SecondName = secondName;
            PhoneNumber = phoneNumber;
            DocDataSeries = docDataSeries;
            DocDataNumber = docDataNumber;
        }
    }
}
