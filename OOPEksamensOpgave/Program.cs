using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            PassengerCar per = new PassengerCar("mazda", DateTime.Now, true, 0.0, "xx12345", 1000, "CE", 1.0, "Benzin", 12.4, 3, 3, 3, 3);
            per.DriversLicenseType = "C";

            Vehicle vagn = per;

            Console.WriteLine(vagn is PassengerCar);
            Console.ReadLine();
        }
    }
}
