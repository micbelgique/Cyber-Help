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
    public partial class RegisterActivity
    {
        private Button _btnOK;
        //private EditText _txtLastName;
        //private EditText _txtFirstName;
        private Spinner _lstRooms;
        private EditText _txtYear;
        private TextView _lblLoading;

        public Button btnOK
        {
            get
            {
                return _btnOK ?? (_btnOK = FindViewById<Button>(Resource.Id.btnOK));
            }
        }

        //public EditText txtLastName
        //{
        //    get
        //    {
        //        return _txtLastName ?? (_txtLastName = FindViewById<EditText>(Resource.Id.txtLastName));
        //    }
        //}

        //public EditText txtFirstName
        //{
        //    get
        //    {
        //        return _txtFirstName ?? (_txtFirstName = FindViewById<EditText>(Resource.Id.txtFirstName));
        //    }
        //}

        public Spinner lstRooms
        {
            get
            {
                return _lstRooms ?? (_lstRooms = FindViewById<Spinner>(Resource.Id.lstRoom));
            }
        }

        public EditText txtYear
        {
            get
            {
                return _txtYear ?? (_txtYear = FindViewById<EditText>(Resource.Id.txtYear));
            }
        }

        public TextView lblLoading
        {
            get
            {
                return _lblLoading ?? (_lblLoading = FindViewById<TextView>(Resource.Id.lblLoading));
            }
        }
    }
}