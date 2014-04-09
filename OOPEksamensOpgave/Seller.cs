using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class Seller
    {
        public PrivatePerson Person { get; private set; }
        public Company Company { get; private set; }

        public Seller(Company company)
        {
            if (company != null)
            {
                Company = company;
            }
        }

        public Seller(PrivatePerson person)
        {
            if (person != null)
            {
                Person = person;
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

        public void ReceivedNotification()
        {
            Console.WriteLine("Company with ZipCode: {0} has received an interesting offer", Company.ZipCode );
        }

       

        public string ID 
        { 
            get
            {
                if (this.Company != null)
                {
                    return Company.CVR;
                }
                else
                {
                    return Person.CPR;
                }
            }
        }

    }
}
