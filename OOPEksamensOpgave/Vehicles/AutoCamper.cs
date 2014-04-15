using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class AutoCamper : Vehicle
    {
        private string _heatingSystem;
        
        //The first constructor which only takes the name as input
        public AutoCamper(string name, string licenseNumber)
            : base(name, licenseNumber)
        {
            InitializeDefault();
        }

        //The second constructor which only takes the name and date of creation as input
        public AutoCamper(string name, string licenseNumber, DateTime year)
            : base(name, licenseNumber, year) 
        {
            InitializeDefault();
        }

        //The third constructor which takes the name, the date of creation and whether the auto camper has a towhitch as input
        public AutoCamper(string name, string licenseNumber, DateTime year, bool towHitch)
            : base(name, licenseNumber, year, towHitch)
        {
            InitializeDefault();
        }

        //The method used to generate random default values
        private void InitializeDefault()
        {
            base.DriversLicenseType = "B";
            base.EngineSize = RandomGenerator.r.Next(3, 7);
            base.Fuel = RandomGenerator.r.Next(0, 2) == 0 ? "Diesel" : "Benzin";
            base.HasBathroom = RandomGenerator.r.Next(0, 2) == 0 ? true : false;
            base.NumSeats = RandomGenerator.r.Next(2, 8);
            this.HeatingSystem = RandomGenerator.r.Next(0, 2) == 0 ? "Gas" : RandomGenerator.r.Next(0, 2) == 0 ? "Electric" : "Oil";
            this.NumSleepingPlaces = RandomGenerator.r.Next(1, 10);
        }

        public int NumSleepingPlaces { get; set; }

        //The property that assigns a value to the _heatingSystem variable
        public string HeatingSystem 
        {
            get { return _heatingSystem; }
            set
            {
                if (value != null)
                {
                    if (value == "Gas")
                    {
                        _heatingSystem = value;
                    }
                    else if (value == "Electric")
                    {
                        _heatingSystem = value;
                    }
                    else if (value == "Oil")
                    {
                        _heatingSystem = value;
                    }
                    else
                    {
                        throw new ArgumentException("Heating system can not be " + value);
                    }
                }
                else
                {
                    throw new ArgumentNullException("The heating system can not be null");
                }
            }
        }

        //Method which overrides the CalculateEnergyClass in vehicles
        //The method calculates which energy class the autocamper is placed in based on heating systems
        protected override string CalculateEnergyClass(int a, int b, int c, double kml)
        {
            double tmpkml;
            if (_heatingSystem == "Oil")
            {
                tmpkml = this.KilometersPerLiter * 0.7;
            }
            else if(_heatingSystem == "Electric")
            {
                tmpkml = this.KilometersPerLiter * 0.8;
            }
            else
            {
                tmpkml = this.KilometersPerLiter * 0.9;
            }
            return base.CalculateEnergyClass(a, b, c, tmpkml);
        }

        public override string ToString()
        {
            return string.Format("This is properties of a autocamper:\n" + base.ToString() + "\nToilet?: {0}\nNumber of sleeping places: {1}\nNumber of seats: {2}"
                + "\nHeating system: {3}", this.HasBathroom, this.NumSleepingPlaces, this.NumSeats, this.HeatingSystem);
        }
    }
}
