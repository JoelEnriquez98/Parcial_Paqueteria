using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class Administrador
    {

        public string code { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public Administrador(string code, string password, string name)
        {
            this.code = code;
            this.password = password;
            this.name = name;
        }

        public Administrador() { }
    }
}