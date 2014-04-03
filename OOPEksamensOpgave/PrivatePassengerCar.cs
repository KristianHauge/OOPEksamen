using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class PrivatePassengerCar : PassengerCar
    {
        public bool IsoFixMounted { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
