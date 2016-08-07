using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Android.Util;
using Gcm.Client;
using WindowsAzure.Messaging;

namespace SummerCamp.CyberHelp.Mobile.Droid.Helper
{
    [BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE },
     Categories = new string[] { "com.SummerCamp.CyberHelp" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK },
     Categories = new string[] { "com.SummerCamp.CyberHelp" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY },
     Categories = new string[] { "com.SummerCamp.CyberHelp" })]
    public class MyBroadcastReceiver : GcmBroadcastReceiverBase<PushHandlerService>
    {
        public static string[] SENDER_IDS = new string[] { Constants.SenderID };

        public const string TAG = "MyBroadcastReceiver-GCM";
    }
}