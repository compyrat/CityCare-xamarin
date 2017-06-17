using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final___Xamarin_Ver.Utils
{
    class Gender
    {
        public static string englishToSpanish(string gender)
        {
            switch (gender)
            {
                case "male":
                    return "Hombre";
                    break;
                case "female":
                    return "Mujer";
                    break;
                default:
                    return "Indefinido";
                    break;
            }
        }
    }
}
