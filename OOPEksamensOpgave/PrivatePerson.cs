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
            if (id > 1)
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

    }
}
