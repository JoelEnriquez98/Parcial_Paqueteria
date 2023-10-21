using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class Model
    {
        public string code { get; set; }
        public string name { get; set; }
        public Model(string code, string name)
        {
            this.code = code;
            this.name = name;
        }
        public Model() { }
    }
}