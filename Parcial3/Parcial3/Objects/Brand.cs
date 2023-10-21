using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class Brand
    {
        public string code { get; set; }
        public string name { get; set; }
        public Brand(string code, string name)
        {
            this.code = code;
            this.name = name;
        }

        public Brand() { }

    }
}