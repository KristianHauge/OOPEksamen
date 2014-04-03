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
            PrivatePassengerCar john = new PrivatePassengerCar();
            john.Fuel = "Diesel";

            Bus per = new Bus();
            per.Fuel = "Diesel";

            Console.ReadLine();
        }
    }
}
