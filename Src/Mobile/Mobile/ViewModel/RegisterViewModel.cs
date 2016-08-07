using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SummerCamp.CyberHelp.Mobile.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private DataService _dataService;
        private string _loading;

        public RegisterViewModel(DataService dataService)
        {
            _dataService = dataService;
            this.User = new Model.User();

            // Commands
            this.SaveCommand = new RelayCommand(SaveCommand_Execute);
            this.SelectRoom = new RelayCommand<Model.Room>(SelectRoom_Execute);

            // List content and default values
            this.Rooms = new ObservableCollection<Model.Room>();
            this.User = new Model.User();
            this.Loading = "Chargement en cours...";

            this.FillViewModel();
        }

        private async void FillViewModel()
        {
            foreach (var room in await _dataService.GetRooms())
            {
                this.Rooms.Add(room);
            }

            this.Loading = String.Empty;
        }

        public Model.User User { get; set; }

        public ObservableCollection<Model.Room> Rooms { get; private set;  }

        public RelayCommand SaveCommand { get; private set; }

        public RelayCommand<Model.Room> SelectRoom { get; private set; }

        public string Loading
        {
            get { return _loading; }
            set
            {
                Set(() => Loading, ref _loading, value);
            }
        }

        private void SaveCommand_Execute()
        {
            _dataService.RegisterUser(this.User);

            var nav = ServiceLocator.Current.GetInstance<INavigationService>();
            nav.NavigateTo(ViewModelLocator.Alert_PageKey);
        }

        private void SelectRoom_Execute(Model.Room room)
        {
            this.User.RoomID = room.ID;
        }
    }
}
