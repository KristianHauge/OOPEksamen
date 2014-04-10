using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class Company
    {
        private static int Id = 0;

        private readonly string _CVR;

        //Constructor that takes balance, credit and adds a unique CVR string to the company
        public Company(decimal balance, decimal credit)
        {
            _CVR = Id.ToString("D8");

            if (Id == 99999999)
            {
                Id = 0;
            }
            else
            {
                Id++;
            }

            Balance = balance;
            Credit = credit;
        }

        //Subscribes the company to the event that updates the balance
        public void SubscribeToEvent(Auction auction)
        {
            auction.UpdateBalanceEvent += UpdateBalance;
        }

        //Removes the company from the event that updates the balance
        public void RemoveFromEvent(Auction auction)
        {
            auction.UpdateBalanceEvent -= UpdateBalance;
        }

        public string CVR 
        { 
            get
            {
                return _CVR;
            }
        }

        public decimal Balance { get; private set; }

        public decimal Credit { get; private set; }

        public int ZipCode { get; set; }

        //Updates the balance of the company
        private void UpdateBalance(Object obj, Auction.PriceArgs e)
        {
            decimal tempBalance = e.Price;

            if (e.Salesman.Company != null && this == e.Salesman.Company)
            {
                    Balance += AuctionHouse.AuctionFee(e.Price);
            }

            else if (e.Buyer.Company != null && this == e.Buyer.Company)
            {
                if (tempBalance > Balance)
                {
                    tempBalance -= Balance;
                    Balance = 0.0M;
                    Credit -= tempBalance;
                }
            }
        }

    }
}
