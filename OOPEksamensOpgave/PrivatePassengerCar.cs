using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class PrivatePassengerCar : PassengerCar
    {
        //Constructor which calls base with some default values
        public PrivatePassengerCar(string name, DateTime year)
            : base(name, year)
        {
        }

        // Constructor which calls base with less default values
        public PrivatePassengerCar(string name, DateTime year, bool towHitch)
            : base(name, year, towHitch)
        {
        }

        // Constructor which calls base with specified values except for bathroom
        public PrivatePassengerCar(string name, DateTime year, bool towHitch, double km, string licenseNumber, double retailPrice, string driversLicenseType,
                                   double engineSize, string fuel, double kilometersPerLiter, int numSeats, double trunkLength, double trunkWidth, 
                                   double trunkHeight, bool isoFixMounted)
            : base(name, year, towHitch, km, licenseNumber, retailPrice, driversLicenseType, engineSize, fuel, kilometersPerLiter, numSeats,
                   trunkLength, trunkWidth, trunkHeight)
        {
            IsoFixMounted = isoFixMounted;
        }

        public bool IsoFixMounted { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
