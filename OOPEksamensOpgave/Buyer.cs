using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class Buyer
    {
        private PrivatePerson _person;
        private Company _company;

        public Buyer(PrivatePerson person)
        {
            if(person != null)
            {
                _person = person;
            }
        }

        public Buyer(Company company)
        {
            if (company != null)
            {
                _company = company;
            }
        }

        private decimal _balance;

        public decimal Balance
        {
            get 
            {
                if (this._company != null)
                {
                    return _company.Balance + _company.Credit;
                }
                else
                {
                    return _person.Balance;
                }
            }
            private set { _balance = value; }
        }
        
    }
}
