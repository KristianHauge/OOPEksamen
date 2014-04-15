using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class Truck : Vehicle
    {
        //The first constructor which only takes the name as input
        public Truck(string name, string licenseNumber)
            : base(name, licenseNumber)
        {
            InitializeDefault();
        }

        // Constructor for truck, sets driver's license to C
        // This ensures that we call property DriversLicenseType
        //Constructor which calls base with some default values
        public Truck(string name, string licenseNumber, DateTime year)
            : base(name, licenseNumber, year)
        {
            InitializeDefault();
        }

        //The third constructor which takes the name, the date of creation and whether the auto camper has a towhitch as input
        public Truck(string name, string licenseNumber, DateTime year, bool towHitch)
            : base(name, licenseNumber, year, towHitch)
        {
            InitializeDefault();
        }

        //The method used to generate random default values
        private void InitializeDefault()
        {
            this.DriversLicenseType = "C";
            base.EngineSize = RandomGenerator.r.Next(5, 16);
            base.Fuel = RandomGenerator.r.Next(0, 2) == 0 ? "Diesel" : "Benzin";
            base.HasBathroom = RandomGenerator.r.Next(0, 2) == 0 ? true : false;
            base.NumSeats = RandomGenerator.r.Next(1, 3);
            this.Weight = RandomGenerator.r.Next(1, 65);
            this.Length = RandomGenerator.r.Next(5, 15);
            this.Height = RandomGenerator.r.Next(2, 5);
            this.LoadCapacity = RandomGenerator.r.Next(10, 45);
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

        public override string ToString()
        {
            return string.Format("This is properties of a truck:\n" + base.ToString() + "\nLoad capacity: {0}\nHeight: {1} m\nLength: {2} m"
                + "\nWeight: {3} ton", this.LoadCapacity, this.Height, this.Length, this.Weight);
        }
    }
}
