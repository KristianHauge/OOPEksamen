using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class Bus : Vehicle
    {

        // Constructor for truck, sets driver's license to C
        // This ensures that we call property DriversLicenseType
        public Bus()
        {
            this.DriversLicenseType = "D";
        }

        //Number of seats in the bus
        public int NumSeats { get; set; }

        //Number of sleeping places in the bus
        public int NumSleepingPlaces { get; set; }

        //Decides whether the bus has a bathroom or not
        public bool HasBathroom { get; set; }

        //The height of the bus
        public double Height { get; set; }

        //The weight of the bus
        public int Weight { get; set; }

        //The lenght of the bus
        public double Length { get; set; }

        //  This is the same as driver's license in the truck class, perhaps look at re-use of code in the SUPER class??
        public override string DriversLicenseType
        {
            get { return base.DriversLicenseType; }
            set
            {
                if (base.TowHitch == true)
                {
                    base.DriversLicenseType = "DE";
                }
                else
                {
                    base.DriversLicenseType = value;
                }
            }
        }
        
    }
}
