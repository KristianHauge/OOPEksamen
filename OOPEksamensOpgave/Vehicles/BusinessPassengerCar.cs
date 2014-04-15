using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class BusinessPassengerCar : PassengerCar
    {
        private int _loadCapacity;

        //The first constructor which only takes the name as input
        public BusinessPassengerCar(string name, string licenseNumber)
            : base(name, licenseNumber)
        {
            InitializeDefault();
        }

        //Constructor which calls base with some default values
        public BusinessPassengerCar(string name, string licenseNumber, DateTime year)
            : base(name, licenseNumber, year)
        {
            InitializeDefault();
        }

        // Constructor which calls base with less default values
        public BusinessPassengerCar(string name, string licenseNumber, DateTime year, bool towHitch)
            : base(name, licenseNumber, year, towHitch)
        {
            InitializeDefault();
        }

        //The method used to generate random default values
        private void InitializeDefault()
        {
            base.DriversLicenseType = "B";
            base.EngineSize = RandomGenerator.r.Next(1, 11);
            base.Fuel = RandomGenerator.r.Next(0, 2) == 0 ? "Diesel" : "Benzin";
            base.NumSeats = 2;
            this.LoadCapacity = RandomGenerator.r.Next(1, 1000);
            this.SafetyBar = RandomGenerator.r.Next(0, 2) == 0 ? false : true;
        }

      
        // Does the car have a safety bar
        public bool SafetyBar { get; set; }

        // The load capacity of the car
        public int LoadCapacity
        {
            get { return _loadCapacity; }
            private set {
                if (value > 750)
                {
                    base.DriversLicenseType = "BE";
                }
                _loadCapacity = value;
            }
        }

        public override string ToString()
        {
            return string.Format("This is properties of a business passenger car:\n" + base.ToString() + "\nSafety bar? {0}\nLoad capacity: {1} kg",
                this.SafetyBar, this.LoadCapacity);
        }
    }
}
