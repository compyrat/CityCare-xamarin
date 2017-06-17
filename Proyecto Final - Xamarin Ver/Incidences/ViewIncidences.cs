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

namespace Proyecto_Final___Xamarin_Ver.Incidences
{
    [Activity(Label = "ViewIncidences")]
    public class ViewIncidences : Activity
    {
        Requests.IncidenceRequest inc;

        List<JSON.Incidence> incidenceArray;

        ListView li;

        ArrayAdapter arrayAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShowList);
            reference();
            listviewMenu();
        }
        private void listviewMenu()
        {
            inc = new Requests.IncidenceRequest();
            incidenceArray = inc.getAllIncidencesData();
            arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);
            foreach (JSON.Incidence incidence in incidenceArray)
            {
                if (incidence.userId.Equals(Intent.GetStringExtra("_id")))
                {
                    arrayAdapter.Add(incidence.title);
                }
            }
            li.Adapter = arrayAdapter;
            li.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                Intent intent = new Intent(this, typeof(ViewIncidenceDetailed));
                intent.PutExtra("id", incidenceArray[args.Position]._id);
                StartActivity(intent);
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
            StartActivity(typeof(ViewIncidences));
        }
    }
}