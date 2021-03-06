﻿using System;
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
    [Activity(Label = "HighScores")]
    public class HighScores : Activity
    {

        private ListView MyListView;
        private List<Player> MyList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.highScores);
            var db = new DataManager();
            MyList = db.GetHighScoreList();
            MyListViewAdapter myAdapter = new MyListViewAdapter(this, MyList);
            MyListView = FindViewById<ListView>(Resource.Id.listHighScores);
            MyListView.Adapter = myAdapter;

            // Create your application here
        }
    }
}