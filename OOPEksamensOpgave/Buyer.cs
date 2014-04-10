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

        //Intializes a buyer of the PrivatePerson class
        public Buyer(PrivatePerson person)
        {
            if (person != null)
            {
                Person = person;
            }

            TempBalanceIfAcceptedBid = person.Balance;
        }

        //Intializes a buyer of the Company class
        public Buyer(Company company)
        {
            if (company != null)
            {
                Company = company;
            }

            TempBalanceIfAcceptedBid = company.Balance + company.Credit;
        }

        private decimal _balance;

        //Calculates the buyer's balance based on the buyer's class (PrivatePerson or Company)
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
        
        private decimal _tempBalanceIfAcceptedBid;

        public decimal TempBalanceIfAcceptedBid
        {
            get
            {
                return _tempBalanceIfAcceptedBid;
            }
            set
            {
                _tempBalanceIfAcceptedBid = value;
            }
        }

    }
}
