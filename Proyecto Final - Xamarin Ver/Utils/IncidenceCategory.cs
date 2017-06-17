using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final___Xamarin_Ver.Utils
{
    class IncidenceCategory
    {
        public static string NumToString(int num)
        {
            switch (num)
            {
                case 0:
                    return "Deterioro de la Vía Pública";
                    break;
                case 1:
                    return "Mobiliario urbano";
                    break;
                case 2:
                    return "Farolas y alumbrado";
                    break;
                case 3:
                    return "Alcantarillado";
                    break;
                case 4:
                    return "Limpieza";
                    break;
                case 5:
                    return "Semáforos y señales de tráfico";
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
                case "Deterioro de la Vía Pública":
                    return 0;
                    break;
                case "Mobiliario urbano":
                    return 1;
                    break;
                case "Farolas y alumbrado":
                    return 2;
                    break;
                case "Alcantarillado":
                    return 3;
                    break;
                case "Limpieza":
                    return 4;
                    break;
                case "Semáforos y señales de tráfico":
                    return 5;
                    break;
                default:
                    return -1;
                    break;
            }
        }
    }
}
