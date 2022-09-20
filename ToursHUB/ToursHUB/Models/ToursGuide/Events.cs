using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using ToursHUB.Models.User;

namespace ToursHUB.Models.ToursGuide
{
    public class Events
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Pagination))]
        public string PaginationId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Pagination Pagination { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Event> EventsList { get; set; }

        [ForeignKey(typeof(EventLocation))]
        public string EventLocationId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public EventLocation EventLocation { get; set; }


        [ForeignKey(typeof(Country))]
        public int CountryId { get; set; }


        [ForeignKey(typeof(City))]
        public int CityId { get; set; }


        [ForeignKey(typeof(Distination))]
        public int DistinationId { get; set; }


        //[ForeignKey(typeof(FoursquareVenues))]
        //public int FoursquareVenuesId { get; set; }
    }

    public class Pagination
    {
       

        public int ObjectCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }

    public class EventLocation
    {
        public string Latitude { get; set; }
        public string Within { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
    }

    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Name))]
        public string NameId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Name Name { get; set; }


        [ForeignKey(typeof(Description))]
        public string DescriptionId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Description Description { get; set; }
       
        public string Url { get; set; }

        [ForeignKey(typeof(StartDate))]
        public string StartDateId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public StartDate Start { get; set; }

        [ForeignKey(typeof(EndDate))]
        public string EndDateId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public EndDate End { get; set; }


        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public bool Listed { get; set; }
        public bool Shareable { get; set; }
        public bool OnlineEvent { get; set; }
        public int TxTimeLimit { get; set; }
        public bool HideStartDate { get; set; }
        public bool HideEndDate { get; set; }
        public string Locale { get; set; }
        public bool IsLocked { get; set; }
        public string PrivacySetting { get; set; }
        public bool IsSeries { get; set; }
        public bool IsSeriesParent { get; set; }
        public bool IsReservedSeating { get; set; }
        
        public string OrganizerId { get; set; }
        public string VenueId { get; set; }
        public string CategoryId { get; set; }
        public object SubcategoryId { get; set; }
        public string FormatId { get; set; }
        public string ResourceUri { get; set; }

        [ForeignKey(typeof(Logo))]
        public string LogoId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Logo Logo { get; set; }

        [ForeignKey(typeof(EventVenue))]
        public string EventVenueId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public EventVenue EventVenue { get; set; }

        [ForeignKey(typeof(Events))]
        public int EventsId { get; set; }
    }

    public class Name
    {
        public string Text { get; set; }
        public string Html { get; set; }
    }

    public class Description
    {
        public string Text { get; set; }
        public string Html { get; set; }
    }

    public class StartDate
    {
        public string Timezone { get; set; }
        public DateTime Local { get; set; }
        public DateTime Utc { get; set; }
    }

    public class EndDate
    {
        public string Timezone { get; set; }
        public DateTime Local { get; set; }
        public DateTime Utc { get; set; }
    }

    public class Logo
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string AspectRatio { get; set; }
        public string EdgeColor { get; set; }
        public bool EdgeColorSet { get; set; }
    }

    public class EventVenue
    {
        [ForeignKey(typeof(Address))]
        public string AddressId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Address Address { get; set; }
        public string ResourceUri { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    

}
