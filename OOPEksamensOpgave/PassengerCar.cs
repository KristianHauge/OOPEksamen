using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class PassengerCar : Vehicle
    {
        private int _numSeats;
        public struct TrunkDimensions
        {
            public double Length;
            public double Width;
            public double Height;
        }

        public TrunkDimensions Trunk;

        public PassengerCar()
        {
            base.DriversLicenseType = "B";
        }

        public int NumSeats
        {
            get { return _numSeats; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Number of seats in passenger cars can't be null");

                if (this is BusinessPassengerCar)
                    _numSeats = 2;
                else if (this is PrivatePassengerCar && (2 <= value && value <= 7))
                    _numSeats = value;
                else
                    throw new ArgumentOutOfRangeException("Number of seats in the passenger car is out of range");
            }
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
