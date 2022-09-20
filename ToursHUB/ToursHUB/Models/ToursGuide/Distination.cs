using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using ToursHUB.Models.Locations;
using ToursHUB.Models.TourMedia;
using ToursHUB.Models.User;

namespace ToursHUB.Models.ToursGuide
{
   public class Distination
    {
        public Distination()
        {
                
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; } //City/Country/Distination/Or Venue
        public int CategoryId { get; set; } //id of Sellected Country/City/Distination/venue

        public string Details { get; set; }

        [ForeignKey(typeof(Image))]
        public string ImageId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Image Image { get; set; }


        [ForeignKey(typeof(Location))]
        public string LocationId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Location Location { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<VedioID> VedioIDs { get; set; }

        public bool IsFavourite { get; set; }

        public bool IsVissible { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<City> Cities { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Events> Events { get; set; }

      


    }
}
