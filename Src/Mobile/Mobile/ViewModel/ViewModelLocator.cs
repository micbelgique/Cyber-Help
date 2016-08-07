using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SummerCamp.CyberHelp.Mobile.ViewModel
{
    public class ViewModelLocator
    {
        public const string Alert_PageKey = "ALERT_PAGE";
        public const string Register_PageKey = "REGISTER_PAGE";
        public const string Status_PageKey = "STATUS_PAGE";

        public RegisterViewModel Register
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterViewModel>();
            }
        }

        public AlertViewModel Alert
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AlertViewModel>();
            }
        }

        public StatusViewModel Status
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StatusViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Design
            }
            else
            {
                SimpleIoc.Default.Register<DataService>();
            }

            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<AlertViewModel>();
            SimpleIoc.Default.Register<StatusViewModel>();
        }
    }
}
