using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class AutoCamper : Vehicle
    {
        private string _heatingSystem;

        public int NumSeats { get; set; }

        public int NumSleepingPlaces { get; set; }

        public bool HasBathroom { get; set; }

        public string HeatingSystem
        {
            get { return _heatingSystem; }
            set
            {
                if (value != null)
                {
                    if (value == "Gas")
                    {
                        _heatingSystem = 
                    }


                }
                else
                {
                    throw new ArgumentException("The fuel type is either null or not benzin nor diesel");
                }
            }
        }
    }
}
