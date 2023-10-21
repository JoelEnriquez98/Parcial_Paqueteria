using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class StateTruck
    {
        public int code { get; set; }
        public string name { get; set; }

        public StateTruck(int code, string name)
        {
            this.code = code;
            this.name = name;
        }
        public StateTruck(string name)
        {
            this.name = name;
        }

        public StateTruck() { }
    }
}