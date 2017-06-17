using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final___Xamarin_Ver.Utils
{
    public class isDateNumeric
    {
        public static bool isIt(string value)
        {
            int n;
            bool num = Int32.TryParse(value.Substring(0, 2), out n);
            bool num2 = Int32.TryParse(value.Substring(3, 2), out n);
            bool num3 = Int32.TryParse(value.Substring(6, 4), out n);
            if (num && num2 && num3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
