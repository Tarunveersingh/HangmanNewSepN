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
using SQLite;
using SQLitePCL;
namespace HangmanNewSep
{
    [Table("Players")]
   public class Player
    {

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int HighScore { get; set; }


        //ToString override to help display player names on spinner without making a custom adapter.
        public override string ToString()
        {
            return this.Name;
        }
    }
}