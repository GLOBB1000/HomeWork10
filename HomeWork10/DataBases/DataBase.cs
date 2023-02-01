using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.DataBases
{
    public abstract class DataBase<T> where T : class
    { 
        protected abstract string PathToDB { get; set; }
        public abstract void Save();
        public abstract void Delete(T t);
        public abstract void Load();
    }
}
