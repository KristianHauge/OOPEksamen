using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public delegate void AcceptOfferDelegate(Object o, Auction.PriceArgs e);
    public delegate void NotifyDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            DateTime birt = new DateTime(1990, 01, 02);

            PrivatePerson Kristian = new PrivatePerson(birt, 150000.0M);

            Company cmp = new Company(1.0M, 1.0M);

            Vehicle meningsfuldbil = new Truck("Blah", new DateTime(2012, 12, 04), true, 10.0, "XX12345", 20.0, "C", 10.0, "Diesel", 17.0, 2, 5.0, 20, 3.0, 100);

            Seller sell = new Seller(cmp);

            AuctionHouse ah = new AuctionHouse();

            int aucN = ah.PutUpForSale(meningsfuldbil, sell, 100000.0M);

            Buyer buyer = new Buyer(Kristian);

            bool receiveYes = ah.OfferRecived(buyer, aucN, 0.1M);

            foreach (Auction john in ah.AuctionList)
            {
                Console.WriteLine(john.Vehicle.Name);
            }

            if (receiveYes == true)
            {
                Console.WriteLine(ah.AcceptOffer(sell, aucN)); 
            }
	        

            foreach (Auction john in ah.AuctionList)
            {
                Console.WriteLine(john.Vehicle.Name);
            }

            Console.WriteLine("____________");

            foreach (Vehicle john in ah.SoldVehicles)
            {
                Console.WriteLine(john.Name);
            }

            Console.ReadLine();
        }
    }
}
