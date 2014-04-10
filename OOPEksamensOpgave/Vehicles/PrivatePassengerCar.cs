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
        public PrivatePassengerCar(string name)
            : base(name)
        {
            InitializeDefault();
        }

        //Constructor which calls base with some default values
        public PrivatePassengerCar(string name, DateTime year)
            : base(name, year)
        {
            InitializeDefault();
        }

        // Constructor which calls base with less default values
        public PrivatePassengerCar(string name, DateTime year, bool towHitch)
            : base(name, year, towHitch)
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
            return base.ToString() + "This is a private car";
        }
    }
}
