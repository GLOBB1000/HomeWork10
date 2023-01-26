using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.DataBases
{
    public abstract class DataBase
    { 
        protected abstract string PathToDB { get; set; }
        public abstract void Save();
        public abstract void Delete();
        public abstract void Load();
    }
}
