using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ToursHUB.Models.Locations;
using ToursHUB.Models.ToursShopCatalog;
using SQLiteNetExtensions.Attributes;
using ToursHUB.Models.ToursGuide;

namespace ToursHUB.Models.User
{
    public class MyTrips
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Notetitle { get; set; }

        public string NoteDescription { get; set; }

        public int UserId { get; set; }
        [ForeignKey(typeof(SecurityOption))]
        public string SecurityOptionId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]

        public SecurityOption Security { get; set; }
        public bool Share { get; set; }

        public int Duration { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Trip> Trips { get; set; }

        public int tripsCount
        {
            get
            {
                return tripsCount;
            }
            set
            {
                tripsCount = Trips.Count;
            }
        }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
         public List<CatalogItem> CatalogItems { get; set; }
    }

    public enum SecurityOption
    {
        Puplic,
        OnlyMe,
        Friend,
        Friends,
    }

    public class Trip
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public bool SetAlarm { get; set; }
        [ForeignKey(typeof(Location))]
        public string ImageId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Image Image { get; set; }


        [ForeignKey(typeof(Location))]
        public string LocationId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]

        public Location Location { get; set; }

        [ForeignKey(typeof(Country))]
        public string CountryId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Country DestinationCountry { get; set; }

        [ForeignKey(typeof(City))]
        public string CityId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public City DestinationCity { get; set; }

        [ForeignKey(typeof(Distination))]
        public string DistinationId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public City DestinationDistination { get; set; }

        [ForeignKey(typeof(Event))]
        public string EventId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Event DestinationEvent { get; set; }

        public string Comments { get; set; }

        [ForeignKey(typeof(MyTrips))]
        public int MyTripsId { get; set; }


    }

   
}
