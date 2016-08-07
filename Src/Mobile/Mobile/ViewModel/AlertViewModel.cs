using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SummerCamp.CyberHelp.Mobile.ViewModel
{
    public class AlertViewModel : ViewModelBase
    {
        private DataService _dataService;
        private string _loading;
        private int _alertLevel;
        private string _alertComments;

        public AlertViewModel(DataService dataService)
        {
            _dataService = dataService;
            this.DisplayStatusCommand = new RelayCommand(DisplayStatusCommand_Execute);
            this.StartAlertCommand = new RelayCommand(StartAlertCommand_Execute);
        }

        public string Loading
        {
            get { return _loading; }
            set
            {
                Set(() => Loading, ref _loading, value);
            }
        }

        public int AlertLevel
        {
            get { return _alertLevel; }
            set
            {
                Set(() => AlertLevel, ref _alertLevel, value);
                RaisePropertyChanged(() => AlertDescription);
            }
        }

        public string AlertComments
        {
            get { return _alertComments; }
            set
            {
                Set(() => AlertComments, ref _alertComments, value);
            }
        }

        public string AlertDescription
        {
            get
            {
                if (this.AlertLevel < 25)
                    return "Le problème concerne plusieurs écoles";
                else if (this.AlertLevel < 75)
                    return "Le problème se déroule au sein de mon école";
                else
                    return "Le problème se déroule au sein de ma classe";
            }
        }

        public RelayCommand DisplayStatusCommand { get; private set; }

        private void DisplayStatusCommand_Execute()
        {
            var nav = ServiceLocator.Current.GetInstance<INavigationService>();
            nav.NavigateTo(ViewModelLocator.Status_PageKey);
        }

        public RelayCommand StartAlertCommand { get; private set; }

        private async void StartAlertCommand_Execute()
        {
            this.Loading = "Enregistrement de l'alerte";

            Model.WebApi.Alert alert = new Model.WebApi.Alert();

            if (this.AlertLevel < 25)
                alert.cyberAlertType = "M";     // Multi
            else if (this.AlertLevel < 75)
                alert.cyberAlertType = "S";     // School
            else
                alert.cyberAlertType = "U";     // Unique

            alert.comment = this.AlertComments;
            alert.statusDescription = this.AlertDescription;
            alert.coordinates = "xxx";
            alert.statusCode = "N";
            alert.cyberHelpUserID = 1;

            await _dataService.SendNewAlertAsync(alert);

            this.Loading = string.Empty;

            // Go to status page
            var nav = ServiceLocator.Current.GetInstance<INavigationService>();
            nav.NavigateTo(ViewModelLocator.Status_PageKey);
        }
    }
}
