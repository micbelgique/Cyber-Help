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
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;

namespace SummerCamp.CyberHelp.Mobile.Droid
{
    public static class App
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (_locator == null)
                {
                    // First time initialization
                    var nav = new NavigationService();
                    nav.Configure(ViewModelLocator.Alert_PageKey, typeof(AlertActivity));
                    nav.Configure(ViewModelLocator.Register_PageKey, typeof(RegisterActivity));
                    nav.Configure(ViewModelLocator.Status_PageKey, typeof(StatusActivity));

                    SimpleIoc.Default.Register<INavigationService>(() => nav);
                    SimpleIoc.Default.Register<IDialogService, DialogService>();

                    _locator = new ViewModelLocator();
                }

                return _locator;
            }
        }
    }
}