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

        //Constructor that takes the birthday of a person, as well as their balance and adds a unique CPR string
        public PrivatePerson(string name, DateTime birthday, decimal balance)
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

            this.Name = name;
            this.ZipCode = RandomGenerator.r.Next(0, 10000);
            Balance = balance;
        }

        public string Name { get; private set; }

        //Subscribes the private person to the event that updates the balance
        public void SubscribeToEvent(Auction auction)
        {
            auction.UpdateBalanceEvent += UpdateBalance;
        }

        //Remove the private person from the event that updates the balance
        public void RemoveFromEvent(Auction auction)
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

        public int ZipCode { get; set; }

        //Updates the balance of the private person
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
