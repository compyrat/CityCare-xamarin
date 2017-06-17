using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace Proyecto_Final___Xamarin_Ver.Users
{
    [Activity(Label = "ViewUserDetailed")]
    public class ViewUserDetailed : Activity
    {
        TextView _id;
        TextView name;
        TextView lastname;
        TextView email;
        TextView password;
        TextView mac;
        TextView state;

        ImageView image;

        Bitmap bitmap;

        Button goToNotification;
        Button blockUser;

        Requests.UserRequests user = new Requests.UserRequests();

        JSON.User us;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewUserDetailed);
            // Create your application here
            this.Title = "CityCare - Usuario";
            reference();
            loadUser();
            events();
        }
        private void reference()
        {
            _id = FindViewById<TextView>(Resource.Id.textView1);
            name = FindViewById<TextView>(Resource.Id.textView2);
            lastname = FindViewById<TextView>(Resource.Id.textView3);
            email = FindViewById<TextView>(Resource.Id.textView4);
            password = FindViewById<TextView>(Resource.Id.textView5);
            mac = FindViewById<TextView>(Resource.Id.textView6);
            state = FindViewById<TextView>(Resource.Id.textView7);

            image = FindViewById<ImageView>(Resource.Id.imageView1);

            goToNotification = FindViewById<Button>(Resource.Id.notbtn);
            blockUser = FindViewById<Button>(Resource.Id.blockbtn);

            us = user.getUserData(Intent.GetStringExtra("id"));
        }
        private void events()
        {
            goToNotification.Click += delegate
            {
                Intent intent = new Intent(this, typeof(SendNotification));
                intent.PutExtra("_id", _id.Text);
                StartActivity(intent);
            };
            blockUser.Click += delegate
            {
                if (us.status == 0)
                {
                    user.blockUser(us._id, "1");
                    blockUser.Text = "Bloquear usuario";
                    us.status = 1;
                }
                else
                {
                    user.blockUser(us._id, "0");
                    blockUser.Text = "Desbloquear usuario";
                    us.status = 0;
                }
                state.Text = Utils.UserStatus.numToString(user.getUserData(us._id).status);
            };
        }
        private void loadUser()
        {
            _id.Text = us._id;
            name.Text = us.name;
            lastname.Text = us.lastname;
            email.Text = us.email;
            password.Text = us.password;
            mac.Text = us.mac;
            state.Text = Utils.UserStatus.numToString(us.status);
            if (us.avatar != null)
            {
                bitmap = Utils.BitmapUrl.GetImageBitmapFromUrl(us.avatar);
                image.SetImageBitmap(bitmap);
            }
            if (us.status == 0)
            {
                blockUser.Text = "Desbloquear usuario";
            }
            else
            {
                blockUser.Text = "Bloquear usuario";
            }
        }
        
    }
}