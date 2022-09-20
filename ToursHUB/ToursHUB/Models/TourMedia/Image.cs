using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace ToursHUB.Models.TourMedia
{
   public class Image
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public ImageSource ImageSource { get; set; }
        public string URL { get; set; }

    }
}
