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

        public List<Auction> AuctionList = new List<Auction>() { };
        public List<Vehicle> SoldVehicles = new List<Vehicle>() { };

        public AuctionHouse()
        {

        }

        public int PutUpForSale(Vehicle vehicle, Seller salesman, decimal minPrice)
        {
            ++_auctionNumber;

            Auction au = new Auction(vehicle, salesman, _auctionNumber, minPrice, salesman.ReceivedNotification);
            AuctionList.Add(au);

            salesman.SubscribeToEvent(au);

            return _auctionNumber;
        }


        public int PutUpForSale(Vehicle vehicle, Seller salesman, decimal minPrice, NotifyDelegate notify)
        {
            ++_auctionNumber;
            
            Auction au = new Auction(vehicle, salesman, _auctionNumber, minPrice, notify);
            AuctionList.Add(au);
            
            return _auctionNumber;
        }

        public bool OfferRecived(Buyer buyer, int auctionNumber, decimal bid)
        {
            Auction auction = AuctionList.First(x => x.AuctionNumber == auctionNumber);
            return auction.BidAuction(bid, buyer);
        }

        public bool AcceptOffer(Seller salesman, int auctionNumber)
        {
            Auction auction = AuctionList.First(x => x.AuctionNumber == auctionNumber);
            if (auction.Salesman.ID == salesman.ID )
            {
                auction.sell();
                SoldVehicles.Add(auction.Vehicle);
                AuctionList.Remove(auction);

                return true;
            }
            else
            {
                return false;
            }
        }

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

    }
}
