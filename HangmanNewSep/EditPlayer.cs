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
using Newtonsoft.Json;

namespace HangmanNewSep
{
    [Activity(Label = "EditPlayer")]
    public class EditPlayer : Activity
    {
        private EditText Name;
        private Button Update;
        private Button Delete;
        private Player SelectedPlayer;
        private DataManager myDataManager;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.editPlayer);
            Name = FindViewById<EditText>(Resource.Id.editPlayerName);
            Update = FindViewById<Button>(Resource.Id.btnUpdatePlayer);
            Update.Click += Update_Click;
            Delete = FindViewById<Button>(Resource.Id.btnDeletePlayer);
            Delete.Click += Delete_Click;
            SelectedPlayer = JsonConvert.DeserializeObject<Player>(Intent.GetStringExtra("UserProfile"));
            Name.Text = SelectedPlayer.Name;
            myDataManager = new DataManager();
            // Create your application here
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            myDataManager.Delete(SelectedPlayer);
            StartActivity(typeof(PlayerSelect));
        }

        //Allow user to change Player name, check if there is text before updating the database, else prompt user to enter a name.
        private void Update_Click(object sender, EventArgs e)
        {
            if (Name.Text != "")
            {
                SelectedPlayer.Name = Name.Text;
                myDataManager.Update(SelectedPlayer);
                StartActivity(typeof(PlayerSelect));
            }
            else
            {
                Toast.MakeText(this, "Please enter your name!", ToastLength.Short).Show();
            }

        }
    }
}