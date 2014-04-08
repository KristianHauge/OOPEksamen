using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class BusinessPassengerCar : PassengerCar
    {
        private int _loadCapacity;

        //Constructor which calls base with some default values
        public BusinessPassengerCar(string name, DateTime year)
            : base(name, year)
        {
            LoadCapacity = 0;
        }

        // Constructor which calls base with less default values
        public BusinessPassengerCar(string name, DateTime year, bool towHitch)
            : base(name, year, towHitch)
        {
            LoadCapacity = 0;
        }

        // Constructor which calls base with specified values except for bathroom
        public BusinessPassengerCar(string name, DateTime year, bool towHitch, double km, string licenseNumber, double retailPrice, string driversLicenseType,
                                   double engineSize, string fuel, double kilometersPerLiter, int numSeats, double trunkLength, double trunkWidth, 
                                   double trunkHeight, bool saftyBar, int loadCapacity)
            : base(name, year, towHitch, km, licenseNumber, retailPrice, driversLicenseType, engineSize, fuel, kilometersPerLiter, numSeats,
                   trunkLength, trunkWidth, trunkHeight)
        {
            SafetyBar = saftyBar;
            LoadCapacity = loadCapacity;
        }
      
        // Does the car have a safety bar
        public bool SafetyBar { get; set; }

        // The load capacity of the car
        public int LoadCapacity
        {
            get { return _loadCapacity; }
            private set {
                if (value > 750)
                {
                    base.DriversLicenseType = "BE";
                }
                _loadCapacity = value;
            }
        }
        
    }
}
