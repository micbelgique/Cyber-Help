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
    public partial class StatusActivity
    {
        private Button _btnOK;
        private TextView _lblLoading;
        private ListView _lstAllAlerts;

        public TextView lblLoading
        {
            get
            {
                return _lblLoading ?? (_lblLoading = FindViewById<TextView>(Resource.Id.lblLoading));
            }
        }

        public Button btnOK
        {
            get
            {
                return _btnOK ?? (_btnOK = FindViewById<Button>(Resource.Id.btnOK));
            }
        }

        public ListView lstAllAlerts
        {
            get
            {
                return _lstAllAlerts ?? (_lstAllAlerts = FindViewById<ListView>(Resource.Id.lstAllAlerts));
            }
        }
    }
}