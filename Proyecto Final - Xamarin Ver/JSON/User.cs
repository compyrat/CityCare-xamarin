using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final___Xamarin_Ver.JSON
{
    public class User
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string _id { get; set; }
        public string id_prov { get; set; }
        public string gender { get; set; }
        public string avatar { get;  set; }
        public string mac {get; set; }
        public int positivePoints { get; set; }
        public int negativePoints { get; set; }
        public int status { get; set; }
        public string numberIncidences { get; set; }
        public string numberIncidencesSolved { get; set; }
        public string accountType { get; set; }
    }
}
