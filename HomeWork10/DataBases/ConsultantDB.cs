using System;
using System.Collections.Generic;
using System.IO;
using HomeWork10.Users;
using Newtonsoft.Json;

namespace HomeWork10.DataBases
{
    public class ConsultantDB : DataBase
    { 
        public static List<Consultant>? Consultants { get; set; }

        private string path;

        protected override string PathToDB
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public ConsultantDB()
        {
            if (Consultants == null)
                Consultants = new List<Consultant>();

            path = Path.Combine(Directory.GetCurrentDirectory(), "ConsData.json");

            if (!File.Exists(PathToDB))
                File.Create(PathToDB);
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            if (File.Exists(PathToDB))
            {
                var json = File.ReadAllText(PathToDB);
                Consultants = JsonConvert.DeserializeObject<List<Consultant>>(json);
            }
        }
        public override void Save()
        {
            var json = JsonConvert.SerializeObject(Consultants);
            File.WriteAllText(PathToDB, json);
        }
    }
}
