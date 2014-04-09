using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class Auction
    {
        public event AcceptOfferDelegate UpdateBalanceEvent;
        public Vehicle Vehicle { get; private set; }
        public Seller Salesman { get; private set; }
        public Buyer HighestBidder { get; private set; }
        public int AuctionNumber { get; private set; }
        public decimal MinPrice { get; private set; }
        public decimal CurrentBid { get; private set; }
        public NotifyDelegate Notify { get; private set; }

        public Auction(Vehicle vehicle, Seller salesman, int auctionNumber, decimal minPrice, NotifyDelegate notify)
        {
            this.Vehicle = vehicle;
            this.Salesman = salesman;
            this.AuctionNumber = auctionNumber;
            this.MinPrice = minPrice;
            this.Notify = notify;
        }

        public bool BidAuction(decimal bid, Buyer buyer)
        {
            if (buyer.Balance >= bid && bid > CurrentBid && bid >= MinPrice)
            {
                CurrentBid = bid;
                if (HighestBidder == null)
                {
                }

                else
                {
                    HighestBidder.RemoveFromEvent(this);
                }

                buyer.SubscribeToEvent(this);
                HighestBidder = buyer;

                if(CurrentBid > MinPrice)
                {
                    Notify();
                }
                return true;
            }

            else
            {
                return false;
            }
        }

        public void sell()
        {
            UpdateBalanceEvent(this, new PriceArgs(CurrentBid, Salesman, HighestBidder));
        }

        public class PriceArgs : EventArgs
        {
            public decimal Price { get; private set; }

            public Seller Salesman { get; private set; }

            public Buyer Buyer { get; private set; }

            public PriceArgs(decimal currentBid, Seller salesman, Buyer buyer)
            {
                Price = currentBid;
                Salesman = salesman;
                Buyer = buyer;
            }
        }
    }
}
