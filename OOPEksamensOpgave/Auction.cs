using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class Auction
    {
        //Properties used throughout the methods
        public event AcceptOfferDelegate UpdateBalanceEvent;
        public Vehicle Vehicle { get; private set; }
        public Seller Salesman { get; private set; }
        public Buyer HighestBidder { get; private set; }
        public int AuctionNumber { get; private set; }
        public decimal MinPrice { get; private set; }
        public decimal CurrentBid { get; private set; }
        public NotifyDelegate Notify { get; private set; }
        
        //Constructor used to make an auction, which requires some parameters
        public Auction(Vehicle vehicle, Seller salesman, int auctionNumber, decimal minPrice, NotifyDelegate notify)
        {
            this.Vehicle = vehicle;
            this.Salesman = salesman;
            this.AuctionNumber = auctionNumber;
            this.MinPrice = minPrice;
            this.Notify = notify;
            if (Salesman.Person != null)
            {
                Salesman.Person.SubscribeToEvent(this);
            }
            else
            {
                Salesman.Company.SubscribeToEvent(this);
            }
        }

        //The method which evaluates whether the auction is being bid on or not
        public bool BidAuction(decimal bid, Buyer buyer)
        {
            //If the buyers balance is larger than the bid and the bid is higher than the current bid 
            //and the minimum price, set the bid to the current bid
            if (buyer.Balance >= bid && bid > CurrentBid && bid >= MinPrice)
            {
                CurrentBid = bid;
                //If a highest bidder is already existing, then remove him from event invocation list
                if (HighestBidder != null)
                {
                    if (HighestBidder.Person != null)
                    {
                        HighestBidder.Person.RemoveFromEvent(this);
                    }
                    else
                    {
                        HighestBidder.Company.RemoveFromEvent(this);
                    }
                }
                //Adds the new highest bidder to the event invocation list
                if (buyer.Person != null)
                {
                    buyer.Person.SubscribeToEvent(this);
                }
                else
                {
                    buyer.Company.SubscribeToEvent(this);
                }

                HighestBidder = buyer;
                //Notifies the seller that an interesting bid has been made
                Notify();

                return true;
            }

            else
            {
                return false;
            }
        }

        //A method which invocates the event to update the balance of the seller and buyer
        public void Sell()
        {
            UpdateBalanceEvent(this, new PriceArgs(CurrentBid, Salesman, HighestBidder));
        }

        //A class that defines the elements in the event to update the balance
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
