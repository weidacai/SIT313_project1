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

namespace Application
{
    [Activity(Label = "313", MainLauncher = true,Icon = "@drawable/icon") ]
    public class MainActivity  : Activity 
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.Main);
            var btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(LoginActivity));
                StartActivity(nextActivity);
            };


        }
    }
}