using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class Truck : Vehicle
    {
        // Constructor for truck, sets driver's license to C
        // This ensures that we call property DriversLicenseType
        //Constructor which calls base with some default values
        public Truck(string name, DateTime year)
            : base(name, year, false, 0.0, "XX12345", 0.0, "C", 0.0, "Diesel", 0.0, 4, false)
        {
            this.Length = 0.0;
            this.Height = 0.0;
            this.Weight = 0;
            this.LoadCapacity = 0;
        }

        // Constructor which calls base with less default values
        public Truck(string name, DateTime year, bool towHitch)
            : base(name, year, towHitch, 0.0, "XX12345", 0.0, "C", 0.0, "Diesel", 0.0, 4, false)
        {
            this.DriversLicenseType = "C";
            this.Length = 0.0;
            this.Height = 0.0;
            this.Weight = 0;
            this.LoadCapacity = 0;
        }

        // Constructor which calls base with specified values except for bathroom
        public Truck(string name, DateTime year, bool towHitch, double km, string licenseNumber, double retailPrice, string driversLicenseType,
                     double engineSize, string fuel, double kilometersPerLiter, int numSeats, double length, int weight, double height, int loadCapacity)
            : base(name, year, towHitch, km, licenseNumber, retailPrice, "C", engineSize, fuel, kilometersPerLiter, numSeats, false)
        {
            this.DriversLicenseType = driversLicenseType;
            this.Length = length;
            this.Height = height;
            this.Weight = weight;
            this.LoadCapacity = loadCapacity;
        }

        // The load capacity of the truck
        public int LoadCapacity { get; set; }

        // The height of the truck
        public double Height { get; set; }

        //The weight of the truck
        public int Weight { get; set; }

        // The lenght of the truck
        public double Length { get; set; }

        // Set the needed driver's license needed for the truck
        public override string DriversLicenseType
        {
            get { return base.DriversLicenseType; }
            set {
                if (base.TowHitch == true)
                {
                    base.DriversLicenseType = "CE";
                }
                else
                {
                    base.DriversLicenseType = value;
                }
            }
        }
        

    }
}
