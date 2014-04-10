using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    public abstract class Vehicle
    {

        private int _numSeats;
        private string _name;
        private double _km;
        private string _licenseNumber;
        public readonly DateTime Year;
        private double _retailPrice;
        public readonly bool TowHitch; // Specifies if the car has a tow hitch // Husk personbil til erhverv
        private string _driversLicenseType;
        private double _engineSize;
        private string _fuel;
        private string _energyClass;


        //The first constructor which only takes the name as input
        protected Vehicle(string name) 
        {
            this.Name = name;
            this.KilometersPerLiter = RandomGenerator.r.Next(8, 31);
            this.Km = RandomGenerator.r.Next(0, 576964);
            this.LicenseNumber = "XX12345";
            this.RetailPrice = RandomGenerator.r.Next(15000, 354875);
            this.TowHitch = RandomGenerator.r.Next(0, 2) == 0 ? true : false;
            this.Year = new DateTime(RandomGenerator.r.Next(1870, 2015), RandomGenerator.r.Next(1, 13), RandomGenerator.r.Next(1, 28));
        }

        //The second constructor which only takes the name and date of creation as input
        protected Vehicle(string name, DateTime date)
            : this(name)
        {
            this.Year = date;
        }

        //The third constructor which takes the name, the date of creation and whether the vehicle has a towhitch as input
        protected Vehicle(string name, DateTime date, bool towHitch)
            : this(name, date)
        {
            this.TowHitch = towHitch;
        }

        //Number of seats in the vehicle
        public int NumSeats
        {
            get { return _numSeats; }
            set
            {
                if (this is BusinessPassengerCar)
                {
                    _numSeats = 2;
                }

                else if (this is PrivatePassengerCar && (2 <= value && value <= 7))
                {
                    _numSeats = value;
                }

                else
                {
                    _numSeats = value;
                }
            }
        }

        //Decides whether the vehicle has a bathroom or not
        public bool HasBathroom { get; set; }

        // Name of the vehicle
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not accepted as a name");
                }
                else
                {
                    _name = value;
                }
            }
        }

        // How many kilometers the vehicle has driven
        public double Km
        {
            get { return _km; }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException("It is not possible to set Km to a negative value");
                }
                else
                {
                    _km = value;
                }
            }
        }
        

        // The number on the vehicle's licenseplate
        public string LicenseNumber
        {
            get {
                return "**" + _licenseNumber.Substring(2, 3) +"***";
            }
            set {
                if (value != null)
                {
                    if (isValidLicenseNumber(value))
                    {
                        _licenseNumber = value;
                    }
                    else
                    {
                        throw new InvalidLicensePlateException("Invalid licensenumber specified"); //Brugerdefineret!
                    }
                }
                else
                {
                    throw new ArgumentNullException("Licenseplate can't be null");
                }
            }
        }

        

        // The retail price of a vehicle
        public double RetailPrice
        {
            get { return _retailPrice; }
            set { 
                if(value < 0.0)
                {
                    _retailPrice = 0.0;
                }
                else
                {
                    _retailPrice = value;
                }
            }
        }

        //Assigns the type of drivers license, if the value isn't null
        public virtual string DriversLicenseType
        {
            get { return _driversLicenseType; }
            set { 
                if(value != null)
                {
                    if (isValidDriversLicense(value))
                    {
                        _driversLicenseType = value; 
                    }
                    else
                    {
                        throw new ArgumentException("Driver's license does not match the criteria");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Driver's license type cannot be null");
                }
            }
        }

        //Checks if the size of the engine fits the vehicle
        public double EngineSize
        {
            get { return _engineSize; }
            set 
            {
                if (this is PassengerCar && 0.7 <= value && value <= 10.0)
                {
                    _engineSize = value;
                }

                else if ((this is Truck || this is Bus) && 4.2 <= value && value <= 15)
                {
                    _engineSize = value;
                }

                else if (this is AutoCamper && 2.4 <= value && value <= 6.2)
                {
                    _engineSize = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException("The engine does not fit the vehicle");
                }
            }
        }

        //Shows how many kilometers the vehicle travels per liter
        public double KilometersPerLiter { get; set; }

        //Specifies the given fuel and checks if compatible
        public string Fuel
        {
            get { return _fuel; }
            set 
            {
                if (value != null && (value == "Diesel" || value == "Benzin"))
                {
                    if (this is Truck || this is Bus)
                    {
                        _fuel = "Diesel";
                    }
                    else
                    {
                        _fuel = value; 
                    }
                }
                else
                {
                    throw new ArgumentException("The fuel type is either null or not benzin nor diesel");
                }
            }
        }

        //Returns the energy class of the vehicle
        public string EnergyClass
        {
            get 
            {
                if (_energyClass == null)
                {
                    GetEnergyClass();
                }
                return _energyClass; 
            }
            set 
            { 
                _energyClass = value; 
            }
        }
                


        /// <summary>
        /// Method which validates a given licensenumber
        /// </summary>
        /// <param name="licenseNumber">String containing the license number</param>
        /// <returns></returns>
        private bool isValidLicenseNumber(string licenseNumber)
        {
            bool isValid = true;
            
            if(licenseNumber.Length != 7)
            {
                return false;
            }

            for (int i = 0; i < licenseNumber.Length; i++)
            {
                if (i < 2)
                {
                    if (!char.IsLetter(licenseNumber[i]))
                    {
                        isValid = false;
                    }
                }
                else
                {
                    if (!char.IsDigit(licenseNumber[i]))
                    {
                        isValid = false;
                    }
                }
            }


            return isValid;
        }

        
        /// <summary>
        /// Checks if a drivers license is in a valid format
        /// </summary>
        /// <param name="driversLicense"></param>
        /// <returns></returns>
        private bool isValidDriversLicense(string driversLicense)
        {
            string[] driversLicenseTypes = { "A", "B", "C", "D", "BE", "CE", "DE" };

            return driversLicenseTypes.Contains(driversLicense.ToUpper());
        }
        /// <summary>
        /// Gets the energy class of the vehicle
        /// </summary>
        /// <returns></returns>
        private string GetEnergyClass()
        {
            if (this.Year.Year < 2010 )
            {
                if (this.Fuel == "Diesel")
                {
                    _energyClass = CalculateEnergyClass(23, 18, 13, this.KilometersPerLiter);
                }
                else
                {
                    _energyClass = CalculateEnergyClass(18, 14, 10, this.KilometersPerLiter);
                }
            }

            else
            {
                if (this.Fuel == "Diesel")
                {
                    _energyClass = CalculateEnergyClass(25, 20, 15, this.KilometersPerLiter);
                }
                else
                {
                    _energyClass = CalculateEnergyClass(20, 16, 12, this.KilometersPerLiter);
                }
            }

            return _energyClass;
        }

        /// <summary>
        /// Calculates the energy class of the vehicle
        /// </summary>
        /// <param name="a">Kilometers per liter for the A and B class</param>
        /// <param name="b">Kilometers per liter for the B and C class</param>
        /// <param name="c">Kilometers per liter for the C and D class</param>
        /// <returns></returns>
        protected virtual string CalculateEnergyClass(int a, int b, int c, double kml)
        {            
            if (kml >= a)
            {
                return "A klasse";
            }

            else if (kml >= b && kml < a)
            {
                return "B klasse";
            }

            else if (kml >= c && kml < b)
            {
                return "C klasse";
            }

            else
            {
                return "D klasse";
            }
        }

        public override string ToString()
        {
            return string.Format("{0} was made in {1}.", this.Name, Year.Year);
        } 
    }
}