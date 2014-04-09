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

        public void SubscribeToEvent2(Auction auction)
        {
            auction.UpdateBalanceEvent += UpdateBalance;
        }

        public void RemoveFromEvent2(Auction auction)
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

        public string ZipCode { get; set; }

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
