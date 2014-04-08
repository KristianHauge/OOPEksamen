using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    delegate void NotifyDelegate();

    class Seller
    {
        private Company _company;
        private PrivatePerson _person;

        public Seller(Company company)
        {
            if (company != null)
            {
                _company = company;
            }
        }

        public void ReceivedNotification()
        {
            Console.WriteLine("Company with ZipCode: {0} has received an interesting offer", _company.ZipCode );
        }

        public Seller(PrivatePerson person)
        {
            if (person != null)
            {
                _person = person;
            }
        }

        public string ID 
        { 
            get
            {
                if (this._company != null)
                {
                    return _company.CVR;
                }
                else
                {
                    return _person.CPR;
                }
            }
        }

    }
}
