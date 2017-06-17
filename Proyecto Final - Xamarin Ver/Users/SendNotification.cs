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
    [Activity(Label = "SendNotification")]
    public class SendNotification : Activity
    {
        EditText title;
        EditText msg;
        Button send;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SendNotification);
            this.Title = "CityCare - Notificación";
            reference();
            // Create your application here
            sendNot();
        }
        private void reference()
        {
            title = FindViewById<EditText>(Resource.Id.editText1);
            msg = FindViewById<EditText>(Resource.Id.editText2);
            send = FindViewById<Button>(Resource.Id.sendbtn);
        }
        private void sendNot()
        {
            send.Click += delegate
            {
                Requests.PushRequest push = new Requests.PushRequest();
                push.sendPush(Intent.GetStringExtra("_id"), title.Text, msg.Text);
                Toast.MakeText(this, "Notificación enviada con éxito", ToastLength.Short).Show();
            };
        }
    }
}