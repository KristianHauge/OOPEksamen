using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class Buyer
    {
        public PrivatePerson Person { get; private set; }
        public Company Company { get; private set; }

        public Buyer(PrivatePerson person)
        {
            if(person != null)
            {
                Person = person;
            }

        }

        public Buyer(Company company)
        {
            if (company != null)
            {
                Company = company;
            }
        }

        public void SubscribeToEvent(Auction auction)
        {
            if (Person != null)
            {
                Person.SubscribeToEvent2(auction);
            }

            else
            {
                Company.SubscribeToEvent2(auction);
            }
        }

        public void RemoveFromEvent(Auction auction)
        {
            if (Person != null)
            {
                Person.RemoveFromEvent2(auction);
            }

            else
            {
                Company.RemoveFromEvent2(auction);
            }
        }

        private decimal _balance;

        public decimal Balance
        {
            get 
            {
                if (this.Company != null)
                {
                    return Company.Balance + Company.Credit;
                }
                else
                {
                    return Person.Balance;
                }
            }
            private set { _balance = value; }
        }
        
    }
}
