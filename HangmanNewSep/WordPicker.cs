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
   public class WordPicker
    {

        private List<string> Wordlist { get; set; }

        public WordPicker(List<string> list)
        {
            Wordlist = list;
        }

        //Call this method to get a random word from the list.
        public string GetRandomWord()
        {
            int randomIndex = new Random().Next(Wordlist.Count);
            string word = Wordlist[randomIndex];

            return word;
        }
    }
}