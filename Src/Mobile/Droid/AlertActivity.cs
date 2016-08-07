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
    public partial class AlertActivity : GalaSoft.MvvmLight.Views.ActivityBase
    {
        public AlertViewModel VM
        {
            get
            {
                return App.Locator.Alert;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.AlertLayout);

            // Binding definition
            this.SetBinding(() => VM.Loading, () => lblLoading.Text);
            this.SetBinding(() => VM.AlertDescription, () => AlertDescription.Text);
            this.SetBinding(() => VM.AlertComments, () => txtComment.Text, mode: BindingMode.TwoWay);

            // Set increment movements
            AlertLevel.ProgressChanged += (sender, e) =>
            {
                const int step = 50;
                e.SeekBar.Progress = ((int)Math.Round((double)e.Progress / (double)step)) * step;
                VM.AlertLevel = e.SeekBar.Progress;
            };

            // Buttons
            btnDisplayStatus.SetCommand("Click", VM.DisplayStatusCommand);
            btnAction.SetCommand("Click", VM.StartAlertCommand);
        }

    }
}