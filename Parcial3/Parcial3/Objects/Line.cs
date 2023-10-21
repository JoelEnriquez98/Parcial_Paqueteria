using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class Line
    {
        public string code { get; set; }
        public string name { get; set; }
        public string codeBrand { get; set; }

        public Line(string code, string name, string codeBrand)
        {
            this.code = code;
            this.name = name;
            this.codeBrand = codeBrand;
        }

        public Line() { }
    }
}