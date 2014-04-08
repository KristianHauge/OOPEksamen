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

        public PrivatePerson(DateTime birthday, string name)
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
            
        }

        public string CPR
        {
            get
            {
                return _CPR;
            }
        }

        public int Balance { get; private set; }

        public string ZipCode { get; set; }

        public void UpdateBalance(Object obj,  arg)
        {
            Balance = Balance + arg.
        }
    }
}
