using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class PrivatePerson
    {
        
        public static int id = 0;

        private readonly string _CPR;

        public PrivatePerson(DateTime birthday, decimal balance)
        {
            _CPR = birthday.ToString("ddMMyy") + id.ToString("D4");
            if (id == 9999)
            {
                id = 0;
            }
            else
            {
                id++;
            }

            Balance = balance;
        }

        public void SubscribeToEvent2(Auction auction)
        {
            auction.UpdateBalanceEvent += UpdateBalance;
        }

        public void RemoveFromEvent2(Auction auction)
        {
            auction.UpdateBalanceEvent -= UpdateBalance;
        }

        public string CPR
        {
            get
            {
                return _CPR;
            }
        }

        public decimal Balance { get; private set; }

        public string ZipCode { get; set; }

        private void UpdateBalance(Object obj,  Auction.PriceArgs e)
        {
            if(e.Salesman.Person != null && this == e.Salesman.Person)
            {
                Balance += AuctionHouse.AuctionFee(e.Price);
            }

            else if (e.Buyer.Person != null && this == e.Buyer.Person)
            {
                Balance -= e.Price;
            }
        }
    }
}
