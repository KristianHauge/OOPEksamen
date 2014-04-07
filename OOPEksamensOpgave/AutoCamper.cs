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

        public AutoCamper(string name, DateTime year)
            : base(name, year, false, 0.0, "XX12345", 0.0, "B", 0.0, "Diesel", 0.0, 4, false)
        {
            this.HeatingSystem = "Gas";
            this.NumSleepingPlaces = 0;
        }

        // Constructor which calls base with less default values
        public AutoCamper(string name, DateTime year, bool towHitch)
            : base(name, year, towHitch, 0.0, "XX12345", 0.0, "B", 0.0, "Diesel", 0.0, 4, false)
        {
            this.DriversLicenseType = "D";
            this.HeatingSystem = "Gas";
            this.NumSleepingPlaces = 0;
        }

        // Constructor which calls base with specified values except for bathroom
        public AutoCamper(string name, DateTime year, bool towHitch, double km, string licenseNumber, double retailPrice, string driversLicenseType,
                          double engineSize, string fuel, double kilometersPerLiter, int numSeats, string heatingSystem, int numSleepingPlaces,
                          bool hasBathroom)
            : base(name, year, towHitch, km, licenseNumber, retailPrice, "B", engineSize, fuel, kilometersPerLiter, numSeats, hasBathroom)
        {
            this.HeatingSystem = heatingSystem;
            this.DriversLicenseType = "B";
            this.NumSleepingPlaces = numSleepingPlaces;
        }

        public int NumSleepingPlaces { get; set; }

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

        protected override string CalculateEnergyClass(int a, int b, int c, double kml)
        {
            double tmpkml;
            if (_heatingSystem == "Gas")
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
    }
}
