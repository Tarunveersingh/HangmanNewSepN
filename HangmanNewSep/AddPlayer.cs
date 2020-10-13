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

namespace HangmanNewSep
{
    [Activity(Label = "AddPlayer")]
    public class AddPlayer : Activity
    {

        private EditText input;
        private Button save;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.newPlayer);
            input = FindViewById<EditText>(Resource.Id.txtInput);
            save = FindViewById<Button>(Resource.Id.btnInsert);
            save.Click += Save_Click;

            // Create your application here
        }


        //There is text create new Player object and add to database, else prompt user to enter a name.
        private void Save_Click(object sender, EventArgs e)
        {
            if (input.Text != "")
            {
                var player = new Player();
                player.Name = input.Text;
                var dbManager = new DataManager();
                dbManager.Insert(player);
                StartActivity(typeof(PlayerSelect));
            }
            else
            {
                Toast.MakeText(this, "Please enter your name!", ToastLength.Short).Show();
            }

        }
    }
}