using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class Bus : Vehicle
    {
        //The first constructor which only takes the name as input
        public Bus(string name)
            : base(name)
        {
            InitializeDefault();
        }

        // Constructor for truck, sets driver's license to C
        // This ensures that we call property DriversLicenseType
        public Bus(string name, DateTime year)
            : base(name, year)
        {
            InitializeDefault();
        }

        // Constructor which calls base with less default values
        public Bus(string name, DateTime year, bool towHitch)
            : base(name, year, towHitch)
        {
            InitializeDefault();
        }

        //The method used to generate random default values
        private void InitializeDefault()
        {
            this.DriversLicenseType = "D";
            base.EngineSize = RandomGenerator.r.Next(5, 16);
            base.Fuel = RandomGenerator.r.Next(0, 2) == 0 ? "Diesel" : "Benzin";
            base.HasBathroom = RandomGenerator.r.Next(0, 2) == 0 ? true : false;
            base.NumSeats = RandomGenerator.r.Next(20, 100);
            this.Weight = RandomGenerator.r.Next(1, 32);
            this.Length = RandomGenerator.r.Next(5, 15);
            this.Height = RandomGenerator.r.Next(2, 5);
            this.NumSleepingPlaces = RandomGenerator.r.Next(1, 10);
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

        public override string ToString()
        {
            return string.Format(base.ToString() + " It has {0} number of seats and {1} places to sleep.",
                NumSeats, NumSleepingPlaces);
        }
    }
}
