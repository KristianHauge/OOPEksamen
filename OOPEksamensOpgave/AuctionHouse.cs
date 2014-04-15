using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class AuctionHouse
    {
        private static int _auctionNumber = 0;

        //Lists of auctions as well as sold vehicles
        private List<Auction> AuctionList = new List<Auction>() { };
        private List<Vehicle> SoldVehicles = new List<Vehicle>() { };

        //Method that puts an auction up for sale
        public int PutUpForSale(Vehicle vehicle, Seller salesman, decimal minPrice)
        {
            if (!AuctionList.Any(x => x.Vehicle.Equals(vehicle)))
            {
                ++_auctionNumber;

                Auction au = new Auction(vehicle, salesman, _auctionNumber, minPrice, salesman.ReceivedNotification);
                AuctionList.Add(au);

                return _auctionNumber;
            }
            else
            {
                Console.WriteLine("The vehicle has already been put up for sale!");
                return AuctionList.Find(x => x.Vehicle.Equals(vehicle)).AuctionNumber;
            }
        }

        //Method that overloads the previous method to make a different notify method
        public int PutUpForSale(Vehicle vehicle, Seller salesman, decimal minPrice, NotifyDelegate notify)
        {
            if (!AuctionList.Any(x => x.Vehicle.Equals(vehicle)))
            {
                ++_auctionNumber;
            
                Auction au = new Auction(vehicle, salesman, _auctionNumber, minPrice, notify);
                AuctionList.Add(au);
            
                return _auctionNumber;
            }
            else
            {
                Console.WriteLine("The vehicle has already been put up for sale!");
                return AuctionList.Find(x => x.Vehicle.Equals(vehicle)).AuctionNumber;
            }
        }

        //Method that returns whether the offer has been received or not
        public bool OfferRecived(Buyer buyer, int auctionNumber, decimal bid)
        {
            if (buyer.TempBalanceIfAcceptedBid >= bid)
            {
                buyer.TempBalanceIfAcceptedBid -= bid;

                Auction auction = AuctionList.First(x => x.AuctionNumber == auctionNumber);

                return auction.BidAuction(bid, buyer);
            }
            else
            {
                return false;
            }
        }

        //Method that returns whether the offer has been accepted or not
        public bool AcceptOffer(Seller salesman, int auctionNumber)
        {
            Auction auction = AuctionList.First(x => x.AuctionNumber == auctionNumber);

            //Checks if it is the correct seller (the one who put up the auction) and whether a valid bid has made.
            if (auction.Salesman.ID == salesman.ID && auction.CurrentBid >= auction.MinPrice)
            {
                auction.Sell();
                SoldVehicles.Add(auction.Vehicle);
                AuctionList.Remove(auction);

                return true;
            }
            else
            {
                return false;
            }
        }

        //Calculates the price of the sale minus the fee to correctly update the balance of the seller
        public static decimal AuctionFee(decimal price)
        {
            decimal Price = price;
            if (price >= 0.0M && price < 10000.0M)
            {
                Price -= 1900.0M;
            }

            else if (price >= 10000.0M && price < 50000.0M)
            {
                Price -= 2250.0M;
            }

            else if (price >=  50000.0M && price < 100000.0M)
            {
                Price -= 2550.0M;
            }

            else if (price >= 100000.0M && price < 150000.0M)
            {
                Price -= 2850.0M;
            }

            else if (price >= 100000.0M && price < 200000.0M)
            {
                Price -= 3400.0M;
            }

            else if (price >= 200000.0M && price < 300000.0M)
            {
                Price -= 3700.0M;
            }

            else
            {
                Price -= 4400.0M;
            }

            return Price;
        }

        //Method that returns a list of vehicles based on a search of keyword
        public List<Vehicle> SearchByName(string keyword)
        {
            IEnumerable<Vehicle> matches = AuctionList
                .Where(x => x.Vehicle.Name == keyword)
                .Select(x => x.Vehicle );

                return matches.ToList<Vehicle>();
        }

        //Method that returns a list of vehicles based on a search of number of seats as well as the need for a bathroom
        public List<Vehicle> SearchByNumSeatsAndBathrooms(int minSeats)
        {
            IEnumerable<Vehicle> matches = AuctionList
                .Where(x => x.Vehicle.NumSeats >= minSeats && x.Vehicle.HasBathroom == true)
                .Select(x => x.Vehicle);

            return matches.ToList<Vehicle>();
        }

        //Method that returns a list of vehicles based on a search of the type of driver's license as well as a maximum weight of the vehicle
        public List<Vehicle> SearchByDriversLicense(string driversLicense, int maxWeight)
        {
            IEnumerable<Vehicle> matches = null;

            if (driversLicense == "C" || driversLicense == "CE")
	        {
                matches = AuctionList
                    .Where(x => x.Vehicle.DriversLicenseType == driversLicense && ((Truck)x.Vehicle).Weight < maxWeight)
                    .Select(x => x.Vehicle);
	        }

            else if (driversLicense == "D" || driversLicense == "DE")
	        {
                matches = AuctionList
                    .Where(x => x.Vehicle.DriversLicenseType == driversLicense && ((Bus)x.Vehicle).Weight < maxWeight)
                    .Select(x => x.Vehicle);
	        }

            return matches.ToList<Vehicle>();
        }

        //Method that returns a list of private cars based on a search of how many kilometers the car has travelled as well as a minimum price
        public List<Vehicle> SearchPrivateCarByKmAndMinimumPrice(int km, int minPrice)
        {
            IEnumerable<Vehicle> matches = AuctionList
                .Where(x => x.Vehicle.Km < km)
                .Where(x => x.MinPrice > minPrice)
                .OrderBy(x => x.Vehicle.Km)
                .Select(x => x.Vehicle);

            return matches.ToList<Vehicle>();
        }

        //Method that returns a list of vehicles based on a search of zip code and radius,
        //which determines whether the auctioned vehicle is close enough
        public List<Vehicle> SearchByZipCodeAndRadius(int zipCode, int radius)
        {
            IEnumerable<Vehicle> matches = AuctionList
                .Where(x => Math.Abs(x.Salesman.ZipCode - zipCode) <= radius)
                .Select(x => x.Vehicle);

            return matches.ToList<Vehicle>();
        }

        //A method that returns the average energy class of all vehicles on the auction list
        //A converted to 1, B converted to 2, C converted to 3, D converted to 4
        public int AverageEnergyClass()
        {
            double averageEnergyClass = AuctionList
                .Select(x =>
                {
                    if (x.Vehicle.EnergyClass == "A")
                        return 1;
                    else if (x.Vehicle.EnergyClass == "B")
                        return 2;
                    else if (x.Vehicle.EnergyClass == "C")
                        return 3;
                    else
                        return 4;
                })
                .Average<int>(x => x);

            int roundedAverage = (int)Math.Round(averageEnergyClass);

            return roundedAverage;
        }
    }
}
