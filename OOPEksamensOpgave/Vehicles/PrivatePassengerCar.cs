using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class PrivatePassengerCar : PassengerCar
    {
        //The first constructor which only takes the name as input
        public PrivatePassengerCar(string name, string licenseNumber)
            : base(name, licenseNumber)
        {
            InitializeDefault();
        }

        //Constructor which calls base with some default values
        public PrivatePassengerCar(string name, string licenseNumber, DateTime year)
            : base(name, licenseNumber, year)
        {
            InitializeDefault();
        }

        // Constructor which calls base with less default values
        public PrivatePassengerCar(string name, string licenseNumber, DateTime year, bool towHitch)
            : base(name, licenseNumber, year, towHitch)
        {
            InitializeDefault();
        }

        //The method used to generate random default values
        private void InitializeDefault()
        {
            Random r = new Random();
            base.DriversLicenseType = "B";
            base.EngineSize = r.Next(1, 11);
            base.Fuel = r.Next(0, 2) == 0 ? "Diesel" : "Benzin";
            base.NumSeats = r.Next(2, 8);
            this.IsoFixMounted = r.Next(0, 2) == 0 ? false : true;
        }

        public bool IsoFixMounted { get; set; }

        public override string ToString()
        {
            return string.Format("This is properties of a private passenger car:\n" + base.ToString() + "\nIsofix? {0}", this.IsoFixMounted);
        }
    }
}
