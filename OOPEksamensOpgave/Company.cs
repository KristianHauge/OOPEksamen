using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEksamensOpgave
{
    class Company
    {
        private static int Id = 0;

        private readonly string _CVR;

        public Company()
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
        }

        public string CVR 
        { 
            get
            {
                return _CVR;
            }
        }

        public int Balance { get; private set; }

        public int Credit { get; private set; }

        public string ZipCode { get; set; }

        public void UpdateBalance(Object obj,  arg)
        {
            //_balance = _balance + arg.
        }

    }
}
