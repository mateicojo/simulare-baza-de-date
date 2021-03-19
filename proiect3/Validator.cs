using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect3
{
    class Validator
    {
        public Validator() { }
        bool isDayValid(string ziua)
        {
            if (Int32.TryParse(ziua, out int numarZi))
            {
                if (numarZi < 1 || numarZi > 31)
                    return false;
            }
            else
                return false;
            return true;
        }

        bool isMonthValid(string luna)
        {
            if (Int32.TryParse(luna, out int numarLuna))
            {
                if (numarLuna < 1 || numarLuna > 12)
                    return false;
            }
            else
                return false;
            return true;
        }

        bool isSumValid(string suma)
        {
            if (Int32.TryParse(suma, out int numarSuma))
            {
                if (numarSuma < 0)
                    return false;
            }
            else
                return false;
            return true;
        }

        public bool isInputValid(string ziua,string luna,string suma,string tip)
        {
            return this.isDayValid(ziua) && this.isMonthValid(luna) && this.isSumValid(suma);
        }
    }
}
