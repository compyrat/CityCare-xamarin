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
using Android.Graphics;


namespace Proyecto_Final___Xamarin_Ver.Incidences
{
    [Activity(Label = "ViewIncidenceDetailed")]
    public class ViewIncidenceDetailed : Activity
    {
        TextView useremail;
        TextView incidence;
        TextView street;
        TextView latlon;
        TextView date;
        TextView status;
        TextView category;

        ImageView image;
        Bitmap bitmap;

        Button state;

        RadioButton inProc;
        RadioButton solved;
        RadioButton denied;
        RadioButton indet;

        JSON.Incidence inci;

        Requests.IncidenceRequest incidenceRequest;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewIncidenceDetailed);
            // Create your application here
            this.Title = "CityCare - Incidencia";
            references();
            loadIncidence();
        }
        private void references()
        {
            incidenceRequest = new Requests.IncidenceRequest();
            incidence = FindViewById<TextView>(Resource.Id.inctext);
            street = FindViewById<TextView>(Resource.Id.streettext);
            date = FindViewById<TextView>(Resource.Id.datetext);
            status = FindViewById<TextView>(Resource.Id.statustext);
            category = FindViewById<TextView>(Resource.Id.categorytext);
            useremail = FindViewById<TextView>(Resource.Id.useremailtext);

            inProc = FindViewById<RadioButton>(Resource.Id.radioButton1);
            solved = FindViewById<RadioButton>(Resource.Id.radioButton2);
            denied = FindViewById<RadioButton>(Resource.Id.radioButton3);
            indet = FindViewById<RadioButton>(Resource.Id.radioButton4);

            state = FindViewById<Button>(Resource.Id.btn4);

            image = FindViewById<ImageView>(Resource.Id.incimage);

            inci = incidenceRequest.getIncidence(Intent.GetStringExtra("id"));

        }
        private void loadIncidence()
        {
            incidence.Text = inci.title;
            useremail.Text = inci.email;
            street.Text = inci.street;
            date.Text = inci.date;
            status.Text = Utils.IncidenceStatus.NumToString(inci.status);
            category.Text = Utils.IncidenceCategory.NumToString(inci.category);
            bitmap = Utils.BitmapUrl.GetImageBitmapFromUrl(Utils.Constants.serverAddress + "incidencias/image/" + inci.imageName);
            image.SetImageBitmap(bitmap);
            useremail.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Users.ViewUserDetailed));
                intent.PutExtra("id", inci.userId);
                StartActivity(intent);
            };
            state.Click += delegate
            {
                int nextStatus = inci.status;
                if(inProc.Checked == true)
                {
                    nextStatus = 2;
                }else if(solved.Checked == true)
                {
                    nextStatus = 3;
                }else if(denied.Checked == true)
                {
                    nextStatus = 4;
                }else if(indet.Checked == true)
                {
                    nextStatus = 5;
                }
                incidenceRequest.changeStatus(inci._id, nextStatus);
                Finish();
            };
            
        }
    }
}