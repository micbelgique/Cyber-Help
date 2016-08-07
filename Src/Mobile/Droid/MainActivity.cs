using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Android.Util;
using Gcm.Client;
using SummerCamp.CyberHelp.Mobile.Droid.Helper;

namespace SummerCamp.CyberHelp.Mobile.Droid
{
    [Activity(Label = "Mons Cyber Help", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
	{
        public static MainActivity instance;

        protected override void OnCreate(Bundle bundle)
        {
            instance = this;

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            RegisterWithGCM();

            // Get our button from the layout resource,
            // and attach an event to it
            Button button1 = FindViewById<Button>(Resource.Id.btnTest1);
            Button button2 = FindViewById<Button>(Resource.Id.btnTest2);
            Button button3 = FindViewById<Button>(Resource.Id.btnTest3);

            button1.Click += delegate
            {
                StartActivity(typeof(RegisterActivity));
            };

            button2.Click += delegate
            {
                StartActivity(typeof(AlertActivity));
            };

            button3.Click += delegate
            {
                StartActivity(typeof(StatusActivity));
            };
        }
    
        private void RegisterWithGCM()
        {
            try
            {
                // Check to ensure everything's set up right
                GcmClient.CheckDevice(this);
                GcmClient.CheckManifest(this);

                // Register for push notifications
                Log.Info("MainActivity", "Registering...");
                GcmClient.Register(this, Constants.SenderID);
            }
            catch (Exception)
            {
            }
            
        }

    }
}


