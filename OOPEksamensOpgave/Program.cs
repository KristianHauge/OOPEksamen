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

            Company cmp = new Company();

            Vehicle vehicle = new Truck("Blah", new DateTime(2012, 12, 04));

            Seller sell = new Seller(cmp);
            

            Console.WriteLine(Kristian.CPR + " " + Malthe.CPR + " " + Martin.CPR + " " + Emil.CPR);

            AuctionHouse ah = new AuctionHouse();

            ah.PutUpForSale(vehicle, sell, 20.0M);

            ah.OfferRecived();

            Console.ReadLine();
        }
    }
}
