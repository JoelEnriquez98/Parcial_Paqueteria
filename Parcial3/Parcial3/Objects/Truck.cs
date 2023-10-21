using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class Truck
    {
        public string matricula { get; set; }
        public string codeModel { get; set; }
        public string codeType { get; set; }
        public string codeLine { get; set; }
        public int codigoState { get; set; }
        public Truck(string matricula, string codeModel, string codeType, string codeLine, int codigoState)
        {
            this.matricula = matricula;
            this.codeModel = codeModel;
            this.codeType = codeType;
            this.codeLine = codeLine;
            this.codigoState = codigoState;
        }
        public Truck() { }
    }
}