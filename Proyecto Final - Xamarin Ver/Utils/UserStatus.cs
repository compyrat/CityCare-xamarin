using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final___Xamarin_Ver.Utils
{
    class UserStatus
    {
        public static string numToString(int num)
        {
            if (num == 0)
            {
                return "Bloqueado";
            }
            else
            {
                return "Activo";
            }
        }
    }
}
