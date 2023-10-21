using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class Addressee
    {
        public int code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string reference { get; set; }
        public string codeVillage { get; set; }

        public Addressee(int code, string name, string address, string reference, string codeVillage)
        {
            this.code = code;
            this.name = name;
            this.address = address;
            this.reference = reference;
            this.codeVillage = codeVillage;
        }
        public Addressee(string name, string address, string reference, string codeVillage)
        {
            this.name = name;
            this.address = address;
            this.reference = reference;
            this.codeVillage = codeVillage;
        }
        public Addressee() { }
    }
}