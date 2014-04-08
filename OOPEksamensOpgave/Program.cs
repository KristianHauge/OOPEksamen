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
            DateTime birt = new DateTime(1990, 01, 02);

            PrivatePerson Kristian = new PrivatePerson(birt, "Kristian");
            PrivatePerson Malthe = new PrivatePerson(birt, "Kristian");
            PrivatePerson Martin = new PrivatePerson(birt, "Kristian");
            PrivatePerson Emil = new PrivatePerson(birt, "Kristian");

            Console.WriteLine(Kristian.CPR + " " + Malthe.CPR + " " + Martin.CPR + " " + Emil.CPR);
            Console.ReadLine();
        }
    }
}
