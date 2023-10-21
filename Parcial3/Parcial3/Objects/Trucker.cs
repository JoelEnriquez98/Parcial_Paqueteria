using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class Trucker
    {
        public string DPI { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }
        public string villageCode { get; set; }

        public Trucker(string DPI, string name, string phone, string address, decimal salary, string villageCode)
        {
            this.DPI = DPI;
            this.name = name;
            this.phone = phone;
            this.address = address;
            this.salary = salary;
            this.villageCode = villageCode;
        }

        public Trucker() { }
    }
}