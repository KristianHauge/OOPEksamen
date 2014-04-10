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
            PrivatePerson BrokeassMalte = new PrivatePerson(birt, 15000.0M);
            PrivatePerson Martin = new PrivatePerson(birt, 150000.0M);

            AuctionHouse AH = new AuctionHouse();

            Company cmp = new Company(1.0M, 1.0M);
            Random r = new Random();

            Buyer buyMalte = new Buyer(BrokeassMalte);

            Seller sellKristian = new Seller(Kristian);
            Seller sellMartin = new Seller(Martin);

            int MartinsAuktionsNr = 0;
            int KristiansAuktionsNr = 0;            

            Vehicle MartinsBil = new PrivatePassengerCar("Lambo");
            Vehicle KristiansBil = new PrivatePassengerCar("Multipla");

            MartinsAuktionsNr = AH.PutUpForSale(MartinsBil, sellMartin, 10000.0M);
            KristiansAuktionsNr = AH.PutUpForSale(KristiansBil, sellKristian, 10000.0M);

            Console.WriteLine(AH.OfferRecived(buyMalte, KristiansAuktionsNr, 15000.0M));

            Console.WriteLine(AH.OfferRecived(buyMalte, MartinsAuktionsNr, 15000.0M));

            Console.WriteLine(buyMalte.Balance);

            Console.WriteLine(AH.AcceptOffer(sellMartin, MartinsAuktionsNr));

            Console.WriteLine(buyMalte.Balance);

            Console.WriteLine(AH.AcceptOffer(sellKristian, KristiansAuktionsNr));

            Console.WriteLine(buyMalte.Balance);


            //for(int i = 0; i < 20; i++){
            //    Console.WriteLine(r.Next(0,2));
            //}





            //Console.WriteLine("Start the madness");

            //foreach (Vehicle item in billiste)
            //{
            //    Console.WriteLine(item.Name);
            //}
            /*
            Seller sell = new Seller(cmp);

            AuctionHouse ah = new AuctionHouse();

            int aucN = ah.PutUpForSale(meningsfuldbil, sell, 100000.0M);

            Buyer buyer = new Buyer(Kristian);

            Flugga = ah.SearchByName("Blah");

            foreach (Vehicle flop in Flugga)
            {
                Console.WriteLine(flop.Name);
            }

            
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
            */

            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
