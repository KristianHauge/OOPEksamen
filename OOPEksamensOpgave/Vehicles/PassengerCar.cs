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
        private double _trunkLength;
        private double _trunkHeight;
        private double _trunkWidth;

        //The first constructor which only takes the name as input
        public PassengerCar(string name)
            : base(name)
        {
            InitializeDefault();
        }

        //Constructor which calls base with some default values
        public PassengerCar(string name, DateTime year)
            : base(name, year)
        {
            InitializeDefault();
        }

        // Constructor which calls base with less default values
        public PassengerCar(string name, DateTime year, bool towHitch)
            : base(name, year, towHitch)
        {
            InitializeDefault();
        }

        //The method used to generate random default values
        private void InitializeDefault()
        {
            this.DriversLicenseType = RandomGenerator.r.Next(0, 2) == 0 ? "B" : "BE";
            _trunkLength = RandomGenerator.r.Next(1, 3);
            _trunkWidth = RandomGenerator.r.Next(1, 3);
            _trunkHeight = 1;
        }

        //Assigns the type of driver's license
        //If the passenger car is private it gets the value B, if business car it gets the value BE
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

        public override string ToString()
        {
            return string.Format(base.ToString() + " It has {0} number of seats and a retail price of {1}. ", NumSeats, RetailPrice);
        }

    }
}
