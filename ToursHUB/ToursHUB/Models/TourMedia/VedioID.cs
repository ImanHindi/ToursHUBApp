using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using ToursHUB.Models.ToursGuide;

namespace ToursHUB.Models.TourMedia
{
  public  class VedioID
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string VedioId { get; set; }
        public string HighThumbnailUrl { get; set; }

        public string MaxResThumbnailUrl { get; set; }



        [ForeignKey(typeof(Country))]
        public int CountryId { get; set; }

        [ForeignKey(typeof(City))]
        public int CityId { get; set; }

       

        [ForeignKey(typeof(Distination))]
        public int DistinationId { get; set; }

    }
}
