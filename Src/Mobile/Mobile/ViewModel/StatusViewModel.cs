using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.Mobile.ViewModel
{
    public class StatusViewModel : ViewModelBase
    {
        private DataService _dataService;
        private string _loading;

        public StatusViewModel(DataService dataService)
        {
            _dataService = dataService;
            this.AllStatus = new ObservableCollection<Model.StatusItem>();

            // Commands
            this.RefreshCommand = new RelayCommand(RefreshCommand_Execute);

            FillViewModelAsync();
        }

        private async Task FillViewModelAsync()
        {
            this.Loading = "Chargement en cours...";

            AllStatus.Clear();

            var alerts = await _dataService.GetAlerts(1);

            foreach (var item in alerts)
            {
                Model.StatusItem status = new Model.StatusItem();

                switch (item.statusCode)
                {
                    case "N":
                        status.State = Model.StatusItemState.New;
                        break;
                    case "V":
                        status.State = Model.StatusItemState.Validated;
                        break;
                    case "I":
                        status.State = Model.StatusItemState.InProgress;
                        break;
                }
                status.Description = item.comment;
                status.CreatedDateFormatted = item.recordedDate.ToString("dd/MM/yyyy HH:mm");

                AllStatus.Add(status);
            }

            this.Loading = String.Empty;
        }

        public string Loading
        {
            get { return _loading; }
            set
            {
                Set(() => Loading, ref _loading, value);
            }
        }

        public ObservableCollection<Model.StatusItem> AllStatus { get; private set; }

        public RelayCommand RefreshCommand { get; private set; }

        private async void RefreshCommand_Execute()
        {
            await FillViewModelAsync();
        }
    }
}
