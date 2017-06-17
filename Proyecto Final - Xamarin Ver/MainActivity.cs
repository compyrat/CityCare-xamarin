using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Proyecto_Final___Xamarin_Ver
{
    [Activity(Label = "Proyecto_Final___Xamarin_Ver", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button login;

        EditText email;
        EditText password;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            this.Title = "CityCare";
           references();
           events();
        }
        private void references()
        {
            login = FindViewById<Button>(Resource.Id.loginButton);
            email = FindViewById<EditText>(Resource.Id.loginEmail);
            password = FindViewById<EditText>(Resource.Id.loginPass);
        }
        private void events()
        {
            login.Click += delegate
            {
                try
                {
                    Requests.UserRequests user = new Requests.UserRequests();
                    List<JSON.User> usersdata = user.getAllUsersData();
                    bool login = false;
                    foreach (JSON.User users in usersdata)
                    {
                        if (email.Text.ToLower().Equals(users.email.ToLower()) && Utils.SecurityUtilities.Sha1Digest(password.Text).Equals(users.password) && users.accountType.ToLower().Equals("admin"))
                        {
                            login = true;
                        }
                    }
                    if (login == true)
                    {
                        StartActivity(typeof(Incidences.ViewMap));
                    }
                    else
                    {
                        Toast.MakeText(this, "Usuario y/o contraseña incorrecta", ToastLength.Short).Show();
                    }
                }
                catch (Exception exception)
                {
                    Toast.MakeText(this, "El servidor no responde", ToastLength.Long).Show();
                }
            };

        }
    }
}

