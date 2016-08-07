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
    public partial class AlertActivity
    {
        private SeekBar _alertLevel;
        private TextView _alertDescription;
        private Button _btnDisplayStatus;
        private ImageButton _btnAction;
        private EditText _txtComment;
        private TextView _lblLoading;

        public TextView lblLoading
        {
            get
            {
                return _lblLoading ?? (_lblLoading = FindViewById<TextView>(Resource.Id.lblLoading));
            }
        }

        public SeekBar AlertLevel
        {
            get
            {
                return _alertLevel ?? (_alertLevel = FindViewById<SeekBar>(Resource.Id.alertLevel));
            }
        }

        public TextView AlertDescription
        {
            get
            {
                return _alertDescription ?? (_alertDescription = FindViewById<TextView>(Resource.Id.alertDescription));
            }
        }


        public Button btnDisplayStatus
        {
            get
            {
                return _btnDisplayStatus ?? (_btnDisplayStatus = FindViewById<Button>(Resource.Id.btnDisplayStatus));
            }
        }

        public ImageButton btnAction
        {
            get
            {
                return _btnAction ?? (_btnAction = FindViewById<ImageButton>(Resource.Id.btnAction));
            }
        }

        public EditText txtComment
        {
            get
            {
                return _txtComment ?? (_txtComment = FindViewById<EditText>(Resource.Id.txtComments));
            }
        }
    }
}