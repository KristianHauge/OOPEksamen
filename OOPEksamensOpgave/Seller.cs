using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public class Seller
    {
        private int _zipCode;
        public PrivatePerson Person { get; private set; }
        public Company Company { get; private set; }

        //Intializes a buyer of the Company class
        public Seller(Company company)
        {
            if (company != null)
            {
                Company = company;
            }
        }

        //Intializes a buyer of the PrivatePerson class
        public Seller(PrivatePerson person)
        {
            if (person != null)
            {
                Person = person;
            }
        }

        //Prints a notification that an interesting bid has been placed
        public void ReceivedNotification()
        {
            if(Person != null)
            {
                Console.WriteLine("Person with zipcode {0}, has recieved an interessting offer.", Person.ZipCode);
            }
            else
            {
                Console.WriteLine("Company with ZipCode: {0} has received an interesting offer", Company.ZipCode);
            }
        }

        //Helps identify the seller as a private person or a company based on either CVR or CPR
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

        //Method that returns a zip code after determining the class (Priavet person or company)
        public int ZipCode
        {
            get 
            {
                if (Person != null)
                {
                    return Person.ZipCode;
                }
                else
                {
                    return Company.ZipCode;
                }
            }
        }
        

    }
}
