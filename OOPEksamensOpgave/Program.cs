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
            //A number of persons
            PrivatePerson Kristian = new PrivatePerson("Kristian", new DateTime(1989, 01, 02), 150000.0M);
            PrivatePerson Malthe = new PrivatePerson("Malthe", new DateTime(1993, 05, 06), 15000.0M);
            PrivatePerson Martin = new PrivatePerson("Martin", new DateTime(1991, 05, 24), 150000.0M);

            //A number of Companies
            Company Mærsk = new Company("Mærsk", 9999999.0M, 500000.0M);
            Company Arriva = new Company("Arriva", 1923994.0M, 300000.0M);
            Company AalborgTaxa = new Company("Aalborg Taxa", 30000.0M, 15000.0M);

            //A number of vehicles
            Truck randomTruck = new Truck("MAN", "YZ39589");
            Bus randomBus = new Bus("Movia", "LO93840");
            AutoCamper randomAutoCamper = new AutoCamper("Knaus", "SE98311");
            AutoCamper randomAutoCamper2 = new AutoCamper("Knaus", "SE98311");
            PassengerCar randomPassengerCar = new PassengerCar("Volvo", "SU30092");
            PrivatePassengerCar randomPrivatePassengerCar = new PrivatePassengerCar("Lamborghini", "DU94304");
            BusinessPassengerCar randomBusinessPassengerCar = new BusinessPassengerCar("Mercedes", "MO23211");
            Vehicle MartinsVehicle = new PrivatePassengerCar("Lamborghini", "XY12345");
            Vehicle KristiansVehicle = new PrivatePassengerCar("Multipla", "HÆ54960");

            //Create an auction house
            AuctionHouse auctionHouse = new AuctionHouse();

            //Functionality of different vehicles
            Console.WriteLine("First part of the assignment:");
            Console.WriteLine(randomPrivatePassengerCar);
            Console.WriteLine("\n" + randomBusinessPassengerCar);
            Console.WriteLine("\n" + randomTruck);
            Console.WriteLine("\n" + randomBus);
            Console.WriteLine("\n" + randomAutoCamper);

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Second part of the assignment: ");

            //Assignment of sellers and buyers
            Buyer buyMærsk = new Buyer(Mærsk);
            Buyer buyArriva = new Buyer(Arriva);
            Buyer buyAalborgTaxa = new Buyer(AalborgTaxa);
            Buyer buyMalthe = new Buyer(Malthe);
            Seller sellKristian = new Seller(Kristian);
            Seller sellMartin = new Seller(Martin);


            //Sellers putting vehicles up for sale
            int kristiansAuctionNumber = auctionHouse.PutUpForSale(KristiansVehicle, sellKristian, 10000.0M);
            int martinsAuctionNumber = auctionHouse.PutUpForSale(MartinsVehicle, sellMartin, 7000.0M);

            //Buyer places offer
            Console.WriteLine("Did the offer on Kristian's vehicle pass?: " + auctionHouse.OfferRecived(buyMalthe, kristiansAuctionNumber, 11000.0M));
            Console.WriteLine("Did the offer on Martin's vehicle pass?: " + auctionHouse.OfferRecived(buyMalthe, martinsAuctionNumber, 11000.0M));
            Console.WriteLine();

            //Seller accepts offer
            Console.WriteLine("Malthe's balance before the buy: " + Malthe.Balance);
            Console.WriteLine("Was the transaction complete?: " + auctionHouse.AcceptOffer(sellKristian, kristiansAuctionNumber));
            Console.WriteLine("Malthe's balance after the buy: " + Malthe.Balance);
            Console.WriteLine();

            //Shows that companies can make use of their credit
            Console.WriteLine("Aalborg taxa's balance before buy: " + AalborgTaxa.Balance + " and credit: " + AalborgTaxa.Credit);
            Console.WriteLine("Did the offer on Martin's vehicle pass?: " + auctionHouse.OfferRecived(buyAalborgTaxa, martinsAuctionNumber, 44591.0M));
            Console.WriteLine("Was the transaction complete?: " + auctionHouse.AcceptOffer(sellMartin, martinsAuctionNumber));
            Console.WriteLine("Malthe's balance after the buy: " + AalborgTaxa.Balance + " and credit: " + AalborgTaxa.Credit);
            Console.WriteLine();

            //Create a lot of auctions
            for (int i = 0; i < 10; i++)
			{
                auctionHouse.PutUpForSale(new Truck(genCarName(), genLicense()), sellKristian, (decimal)RandomGenerator.r.Next(1000, 150000));
                auctionHouse.PutUpForSale(new Bus(genCarName(), genLicense()), sellKristian, (decimal)RandomGenerator.r.Next(1000, 150000));
                auctionHouse.PutUpForSale(new AutoCamper(genCarName(), genLicense()), sellKristian, (decimal)RandomGenerator.r.Next(1000, 150000));
                auctionHouse.PutUpForSale(new PassengerCar(genCarName(), genLicense()), sellMartin, (decimal)RandomGenerator.r.Next(1000, 150000));
                auctionHouse.PutUpForSale(new PrivatePassengerCar(genCarName(), genLicense()), sellKristian, (decimal)RandomGenerator.r.Next(1000, 150000));
                auctionHouse.PutUpForSale(new BusinessPassengerCar(genCarName(), genLicense()), sellMartin, (decimal)RandomGenerator.r.Next(1000, 150000));   
			}

            //Queries
            Console.WriteLine("Below is a search based on driver's license and weight:");
            List<Vehicle> query1 = auctionHouse.SearchByDriversLicense("D", 13);
            foreach (Vehicle item in query1)
	        {
		        Console.WriteLine(item.Name);
	        }

            Console.WriteLine("\nBelow is search based on vehicle name:");
            List<Vehicle> query2 = auctionHouse.SearchByName("Batmobil");
            foreach (Vehicle item in query2)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\nBelow is a search based on a minimum number of seats in vehicles that has a bathroom");
            List<Vehicle> query3 = auctionHouse.SearchByNumSeatsAndBathrooms(7);
            foreach (Vehicle item in query3)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\nBelow is a search based on the seller's zip code and a defined radius");
            List<Vehicle> query4 = auctionHouse.SearchByZipCodeAndRadius(4000, 3000);
            foreach (Vehicle item in query4)
            {
                Console.WriteLine(item.Name);   
            }

            Console.WriteLine("\nBelow is a search on private cars based on kilometers traveled and a minimum price");
            List<Vehicle> query5 = auctionHouse.SearchPrivateCarByKmAndMinimumPrice(400000, 100000);
            foreach (Vehicle item in query5)
            {
                Console.WriteLine(item.Name);
            }


            System.Console.WriteLine("\nOutputs the average energy class the cars in auction house");
            Console.WriteLine(auctionHouse.AverageEnergyClass());

            Console.ReadLine();
        }

        // Method for generating random licenseplate numbers which meets the requirements
        public static string genLicense()
        {
            string licenseNumber;
            char c1 = Convert.ToChar(RandomGenerator.r.Next((int)'A', (int)'['));
            char c2 = Convert.ToChar(RandomGenerator.r.Next((int)'A', (int)'['));
            licenseNumber = c1.ToString() + c2.ToString() + RandomGenerator.r.Next(0, 100000).ToString("D5");

            return licenseNumber;
        }

        // Method for generating random vehicle names
        public static string genCarName()
        {
            List<string> names = new List<string> { "Volvo", "Audi", "BMW", "Jaguar", "Fiat", "Ford", "VW", "Batmobil", "Mercedes", "Peugeot", "Mustang", 
                                              "Aston Martin", "Citroén", "Mini", "Zonda", "Honda", "Hyundai", "Nissan", "Mazda" };
            return names[RandomGenerator.r.Next(0, names.Count)];
        }
    }
}
