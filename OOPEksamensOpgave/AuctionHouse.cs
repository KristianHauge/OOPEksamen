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

        List<Auction> AuctionList = new List<Auction>() { };
        List<Vehicle> SoldVehicles = new List<Vehicle>() { };

        public AuctionHouse()
        {

        }

        public int PutUpForSale(Vehicle vehicle, Seller salesman, decimal minPrice)
        {
            Auction au = new Auction(vehicle, salesman, _auctionNumber, minPrice, salesman.ReceivedNotification);
            AuctionList.Add(au);

            return ++_auctionNumber;
        }


        public int PutUpForSale(Vehicle vehicle, Seller salesman, decimal minPrice, NotifyDelegate notify)
        {
            Auction au = new Auction(vehicle, salesman, _auctionNumber, minPrice, notify);
            AuctionList.Add(au);
            
            return ++_auctionNumber;
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
            }
        }

    }
}
