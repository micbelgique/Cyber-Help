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
using SummerCamp.CyberHelp.Mobile.ViewModel;
using GalaSoft.MvvmLight.Helpers;

namespace SummerCamp.CyberHelp.Mobile.Droid
{
    [Activity(Label = "Mons Cyber Help", Icon = "@drawable/icon")]
    public partial class StatusActivity : GalaSoft.MvvmLight.Views.ActivityBase
    {
        public StatusViewModel VM
        {
            get
            {
                return App.Locator.Status;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.StatusLayout);

            // Binding definition
            this.SetBinding(() => VM.Loading, () => lblLoading.Text);

            // List of rooms
            lstAllAlerts.Adapter = VM.AllStatus.GetAdapter(GetStatusItemAdapter);

            // Buttons
            btnOK.SetCommand("Click", VM.RefreshCommand);
        }

        /// <summary>
        /// Returns a Status Item Template filled with room data
        /// </summary>
        /// <param name="position"></param>
        /// <param name="room"></param>
        /// <param name="convertView"></param>
        /// <returns></returns>
        private View GetStatusItemAdapter(int position, Model.StatusItem status, View convertView)
        {
            convertView = LayoutInflater.Inflate(Resource.Layout.StatusItemTemplate, null);

            // Large Text
            var item1 = convertView.FindViewById<TextView>(Resource.Id.StatusItemName);
            item1.Text = status.Description;
            item1.SetTextColor(Android.Graphics.Color.ParseColor(status.StateColor));
            
            // Small Text
            var item2 = convertView.FindViewById<TextView>(Resource.Id.StatusItemDescription);
            item2.Text = status.StateFormatted;
            item2.SetTextColor(Android.Graphics.Color.ParseColor(status.StateColor));

            var img = convertView.FindViewById<ImageView>(Resource.Id.StatusItemImage);

            switch (status.State)
            {
                case Model.StatusItemState.New:
                    img.SetImageResource(Resource.Drawable.state_send);
                    break;
                case Model.StatusItemState.InProgress:
                    img.SetImageResource(Resource.Drawable.state_progress);
                    break;
                case Model.StatusItemState.Validated:
                    img.SetImageResource(Resource.Drawable.state_validate);
                    break;
            }
            

            return convertView;
        }
    }
}