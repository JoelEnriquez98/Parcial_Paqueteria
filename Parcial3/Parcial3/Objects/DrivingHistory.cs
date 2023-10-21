using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Objects
{
    public class DrivingHistory
    {
        public int codeControl { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime returnDate { get; set; }
        public string vehicleInitialState { get; set; }
        public string vehicleFinalState { get; set; }
        public string carRegistration { get; set; }
        public int initialMileage { get; set; }
        public int finalMileage { get; set; }
        public Boolean vehicleAvailability { get; set; }
        public string DPI { get; set; }

        public DrivingHistory(int codeControl, DateTime departureDate, DateTime returnDate, string vehicleInitialState, string vehicleFinalState, string carRegistration, int initialMileage, int finalMileage, bool vehicleAvailability, string DPi)
        {
            this.codeControl = codeControl;
            this.departureDate = departureDate;
            this.returnDate = returnDate;
            this.vehicleInitialState = vehicleInitialState;
            this.vehicleFinalState = vehicleFinalState;
            this.carRegistration = carRegistration;
            this.initialMileage = initialMileage;
            this.finalMileage = finalMileage;
            this.vehicleAvailability = vehicleAvailability;
            this.DPI = DPi;
        }

        public DrivingHistory(DateTime departureDate, DateTime returnDate, string vehicleInitialState, string vehicleFinalState, string carRegistration, int initialMileage, int finalMileage, bool vehicleAvailability, string DPi)
        {
            this.departureDate = departureDate;
            this.returnDate = returnDate;
            this.vehicleInitialState = vehicleInitialState;
            this.vehicleFinalState = vehicleFinalState;
            this.carRegistration = carRegistration;
            this.initialMileage = initialMileage;
            this.finalMileage = finalMileage;
            this.vehicleAvailability = vehicleAvailability;
            this.DPI = DPi;
        }
        public DrivingHistory() { }
    }
}