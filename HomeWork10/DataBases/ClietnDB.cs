using HomeWork10.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HomeWork10.DataBases
{
    internal class ClientDB : DataBase<Client>
    {
        public static List<Client>? Clients { get; set; }

        private string path;

        protected override string PathToDB {

            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public ClientDB()
        {
            if (Clients == null)
                Clients = new List<Client>();

            path = Path.Combine(Directory.GetCurrentDirectory(), "UsersData.json");

            if (!File.Exists(PathToDB))
                File.Create(PathToDB);
        }

        public override void Delete(Client client)
        {
            if (client != null)
                Clients.Remove(client);

            Save();
        }

        public void SortClients()
        {
            Clients.OrderBy(x => x.Id);
        }

        public override void Load()
        {
            if (File.Exists(PathToDB))
            {
                try
                {
                    var json = File.ReadAllText(PathToDB);
                    Clients = JsonConvert.DeserializeObject<List<Client>>(json);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public override void Save()
        {
            var json = JsonConvert.SerializeObject(Clients);
            File.WriteAllText(PathToDB, json);
        }
    }
}
