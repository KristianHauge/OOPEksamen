using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class Truck : Vehicle
    {
        // Constructor for truck, sets driver's license to C
        // This ensures that we call property DriversLicenseType
        public Truck()
        {
            this.DriversLicenseType = "C";
        }

        // The load capacity of the truck
        public int LoadCapacity { get; set; }

        // The height of the truck
        public double Height { get; set; }

        //The weight of the truck
        public int Weight { get; set; }

        // The lenght of the truck
        public double Length { get; set; }

        // Set the needed driver's license needed for the truck
        public override string DriversLicenseType
        {
            get { return base.DriversLicenseType; }
            set {
                if (base.TowHitch == true)
                {
                    base.DriversLicenseType = "CE";
                }
                else
                {
                    base.DriversLicenseType = value;
                }
            }
        }
        

    }
}
