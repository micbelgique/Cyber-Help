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
    public partial class RegisterActivity : GalaSoft.MvvmLight.Views.ActivityBase
    {
        public RegisterViewModel VM
        {
            get
            {
                return App.Locator.Register;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RegisterLayout);

            // Binding definition
            //this.SetBinding(() => VM.User.LastName, () => txtLastName.Text, mode: BindingMode.TwoWay);
            //this.SetBinding(() => VM.User.FirstName, () => txtFirstName.Text, mode: BindingMode.TwoWay);
            this.SetBinding(() => VM.User.Year, () => txtYear.Text, mode: BindingMode.TwoWay);
            this.SetBinding(() => VM.Loading, () => lblLoading.Text);


            // List of rooms
            lstRooms.Adapter = VM.Rooms.GetAdapter(GetRoomAdapter);
            lstRooms.ItemSelected += (sender, e) => 
            {
                VM.SelectRoom.Execute(VM.Rooms[e.Position]);
            };

            // Buttons
            btnOK.SetCommand("Click", VM.SaveCommand);
        }

        /// <summary>
        /// Returns a Room Item Template filled with room data
        /// </summary>
        /// <param name="position"></param>
        /// <param name="room"></param>
        /// <param name="convertView"></param>
        /// <returns></returns>
        private View GetRoomAdapter(int position, Model.Room room, View convertView)
        {
            convertView = LayoutInflater.Inflate(Resource.Layout.RoomItemTemplate, null);

            var title = convertView.FindViewById<TextView>(Resource.Id.RoomName);
            title.Text = room.Name;

            return convertView;
        }

    }
}