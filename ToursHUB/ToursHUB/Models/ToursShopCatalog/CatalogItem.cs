using SQLiteNetExtensions.Attributes;
using System;
using ToursHUB.Models.Locations;
using ToursHUB.Models.TourMedia;
using ToursHUB.Models.ToursGuide;
using ToursHUB.Models.User;

namespace ToursHUB.Models.ToursShopCatalog
{
    public class CatalogItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int CatalogBrandId { get; set; }
        public string CatalogBrand { get; set; }
        public int CatalogTypeId { get; set; }
        public string CatalogType { get; set; }
        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

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