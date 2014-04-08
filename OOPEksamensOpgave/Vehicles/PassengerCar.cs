using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class PassengerCar : Vehicle
    {
        // Private readonly fields for declaring trunk dimensions
        private readonly double _trunkLength;
        private readonly double _trunkHeight;
        private readonly double _trunkWidth;

        //Constructor which calls base with some default values
        public PassengerCar(string name, DateTime year)
            : base(name, year, false, 0.0, "XX12345", 0.0, "B", 0.0, "Benzin", 0.0, 4, false)
        {
            _trunkLength = 0.0;
            _trunkWidth = 0.0;
            _trunkHeight = 0.0;
        }

        // Constructor which calls base with less default values
        public PassengerCar(string name, DateTime year, bool towHitch)
            : base(name, year, towHitch, 0.0, "XX12345", 0.0, "B", 0.0, "Benzin", 0.0, 4, false)
        {
            _trunkLength = 0.0;
            _trunkWidth = 0.0;
            _trunkHeight = 0.0;
        }

        // Constructor which calls base with specified values except for bathroom
        public PassengerCar(string name, DateTime year, bool towHitch, double km, string licenseNumber, double retailPrice, string driversLicenseType,
                          double engineSize, string fuel, double kilometersPerLiter, int numSeats, double trunkLength, double trunkWidth, double trunkHeight)
            : base(name, year, towHitch, km, licenseNumber, retailPrice, "B", engineSize, fuel, kilometersPerLiter, numSeats, false)
        {
            this.DriversLicenseType = driversLicenseType;
            _trunkLength = trunkLength;
            _trunkWidth = trunkWidth;
            _trunkHeight = trunkHeight;
        }
        
        public override string DriversLicenseType
        {
            get { return base.DriversLicenseType; }
            set
            {
                if (this is PrivatePassengerCar)
                {
                    base.DriversLicenseType = "B";
                }
                else if (this is BusinessPassengerCar && (value == "B" || value == "BE"))
                {
                    base.DriversLicenseType = value;
                }
            }
        }
    }
}
