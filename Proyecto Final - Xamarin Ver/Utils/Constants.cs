using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Proyecto_Final___Xamarin_Ver.Utils
{
    class Constants
    {
        public static string serverAddress { get { return "http://104.155.1.24:3131/"; } }
        public static string serverStatus { get { return "/status"; } }
        public static string registerUserURL { get { return "users/login/register"; } }
        public static string getUserData { get { return "users/summary/"; } }
        public static string getAllUsersType { get { return "users/count"; } }
        public static string getAllUsersData { get { return "users/summaryAll"; } }
        public static string editUserData { get { return "users/edituser"; } }
        public static string deleteUserData { get { return "users/deleteuser/"; } }
        public static string getAllIncidencesData { get { return "incidencias/incidencesAll"; } }
        public static string getIncidence { get { return "incidencias/find/"; } }
        public static string checkRead { get { return "incidencias/checkRead/"; } }
        public static string setStatus { get { return "incidencias/setStatus/"; } }
        public static string sendPush { get { return "users/sendPush"; } }
        public static string deleteIncidence { get { return "incidencias/delete/"; } }
        public static string blockUser { get { return "users/ban"; } }
        public static string getCount { get { return "incidencias/count/"; } }
        public static string getCountAll { get { return "incidencias/countAll"; } }
        public static string getCountSolved { get { return "incidencias/countSolved/"; } }
        public static string getAllCategory { get { return "incidencias/countAllCategory"; } }
    }
}