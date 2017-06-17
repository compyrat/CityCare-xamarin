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

namespace Proyecto_Final___Xamarin_Ver.Users
{
    [Activity(Label = "ViewUser")]
    public class ViewUser : Activity
    {
        Requests.UserRequests users;

        List<JSON.User> userArray;

        ListView li;

        ArrayAdapter a;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShowList);
            StartActivity(typeof(Incidences.ViewMap));
            reference();
            listviewMenu();
        }
        private void listviewMenu()
        {
            users = new Requests.UserRequests();
            userArray = users.getAllUsersData();
            a = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);
            foreach (JSON.User user in userArray)
            {
                a.Add(user.email);
            }
            li.Adapter = a;
            li.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                Intent inte = new Intent(this, typeof(ViewUserDetailed));
                inte.PutExtra("id", userArray[args.Position]._id);
                StartActivity(inte);
                // Toast.MakeText(this, userArray[args.Position].name, ToastLength.Short).Show();

            };
        }
        private void reference()
        {
            li = FindViewById<ListView>(Resource.Id.listView1);

        }

        protected override void OnRestart()
        {
            base.OnRestart();
            this.Finish();
            StartActivity(typeof(ViewUser));
        }
    }
}