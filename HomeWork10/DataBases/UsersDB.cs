using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Nodes;
using HomeWork10.Users;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HomeWork10.DataBases
{
    public class UsersDB : DataBase
    { 
        public static List<User>? Users { get; set; }

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

        public UsersDB()
        {
            if (Users == null)
                Users = new List<User>();

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
                try
                {
                    var json = File.ReadAllText(PathToDB);
                    var s = JsonConvert.DeserializeObject<List<Object>>(json);

                    foreach (var item in s)
                    {
                        var jO = (JObject)item;
                        var ch = jO.Children();
                        var t = ch.ToList();

                        var tU = t.Find(x => x.Path == "U_Type")?.First().ToString();
                        var lU = t.Find(x => x.Path == "Login")?.First().ToString();
                        var pU = t.Find(x => x.Path == "Password")?.First().ToString();

                        if (Users == null)
                            Users = new List<User>();


                        if (tU == "Manager")
                            Users.Add(new Manager(lU, pU, tU));

                        else
                            Users.Add(new Consultant(lU, pU, tU));
                    }
                }

                catch(Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }
        public override void Save()
        {
            var json = JsonConvert.SerializeObject(Users);
            File.WriteAllText(PathToDB, json);
        }
    }
}
