using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final___Xamarin_Ver.Utils
{
    class IncidenceStatus
    {
        public static string NumToString(int num)
        {
            switch (num)
            {
                case 0:
                    return "En trámite";
                    break;
                case 1:
                    return "Leída";
                    break;
                case 2:
                    return "En proceso";
                    break;
                case 3:
                    return "Solucionada";
                    break;
                case 4:
                    return "Rechazada";
                    break;
                case 5:
                    return "Indeterminada";
                    break;
                default:
                    return null;
                    break;
            }
        }
        public static int StringToNum(string num)
        {
            switch (num)
            {
                case "En trámite":
                    return 0;
                    break;
                case "Leída":
                    return 1;
                    break;
                case "En proceso":
                    return 2;
                    break;
                case "Solucionada":
                    return 3;
                    break;
                case "Rechazada":
                    return 4;
                    break;
                case "Indeterminada":
                    return 5;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
