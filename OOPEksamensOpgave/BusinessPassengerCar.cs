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

        // Temp constructor
        public BusinessPassengerCar(int load)
        {
            LoadCapacity = load;
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
        
    }
}
