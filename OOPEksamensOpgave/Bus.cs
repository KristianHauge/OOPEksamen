using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class Bus : Vehicle
    {

        // Constructor for truck, sets driver's license to C
        // This ensures that we call property DriversLicenseType
        public Bus(string name, DateTime year)
            : base(name, year, false, 0.0, "XX12345", 0.0, "D", 0.0, "Diesel", 0.0, 4, false)
        {
            this.Length = 0.0;
            this.Height = 0.0;
            this.Weight = 0;
            this.NumSleepingPlaces = 0;
        }

        // Constructor which calls base with less default values
        public Bus(string name, DateTime year, bool towHitch)
            : base(name, year, towHitch, 0.0, "XX12345", 0.0, "D", 0.0, "Diesel", 0.0, 4, false)
        {
            this.DriversLicenseType = "D";
            this.Length = 0.0;
            this.Height = 0.0;
            this.Weight = 0;
            this.NumSleepingPlaces = 0;
        }

        // Constructor which calls base with specified values except for bathroom
        public Bus(string name, DateTime year, bool towHitch, double km, string licenseNumber, double retailPrice, string driversLicenseType,
                     double engineSize, string fuel, double kilometersPerLiter, int numSeats, double length, int weight, double height, 
                     int numSleepingPlaces, bool hasBathroom)
            : base(name, year, towHitch, km, licenseNumber, retailPrice, "D", engineSize, fuel, kilometersPerLiter, numSeats, hasBathroom)
        {
            this.DriversLicenseType = driversLicenseType;
            this.Length = length;
            this.Height = height;
            this.Weight = weight;
            this.NumSleepingPlaces = numSleepingPlaces;
        }

        //Number of sleeping places in the bus
        public int NumSleepingPlaces { get; set; }

        //The height of the bus
        public double Height { get; set; }

        //The weight of the bus
        public int Weight { get; set; }

        //The lenght of the bus
        public double Length { get; set; }

        //  This is the same as driver's license in the truck class, perhaps look at re-use of code in the SUPER class??
        public override string DriversLicenseType
        {
            get { return base.DriversLicenseType; }
            set
            {
                if (base.TowHitch == true)
                {
                    base.DriversLicenseType = "DE";
                }
                else
                {
                    base.DriversLicenseType = value;
                }
            }
        }
        
    }
}
