using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class Package
    {
        public string code { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public decimal weight { get; set; }
        public int codeAddressee { get; set; }
        public int codeControl { get; set; }

        public Package(string code, string description, string type, decimal weight, int codeAddressee, int codeControl)
        {
            this.code = code;
            this.description = description;
            this.type = type;
            this.weight = weight;
            this.codeAddressee = codeAddressee;
            this.codeControl = codeControl;
        }

        public Package() { }
    }
}