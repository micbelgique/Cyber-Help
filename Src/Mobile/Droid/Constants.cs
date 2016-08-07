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

namespace SummerCamp.CyberHelp.Mobile.Droid
{
    public static class Constants
    {
        public const string SenderID = "[YOUR_KEY]"; // Google API Project Number
        public const string ListenConnectionString = "Endpoint=sb://trasyscyberhelpnotification.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=[YOUR_KEY]";
        public const string NotificationHubName = "TrasysCyberHelpHub";
    }
}