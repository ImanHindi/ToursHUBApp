using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using ToursHUB.Models.User;
using ToursHUB.Models.Locations;
using ToursHUB.Models.TourMedia;

namespace ToursHUB.Models.ToursGuide
{
   public class Distinations
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        [ForeignKey(typeof(Image))]
        public string ImageId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Image Image { get; set; }
        [ForeignKey(typeof(Meta))]
        public string MetaId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Meta Meta { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Notification> Notifications { get; set; }


        [ForeignKey(typeof(Response))]
        public string ResponseId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Response Response { get; set; }

        [ForeignKey(typeof(City))]
        public int CityId { get; set; }

        //[ForeignKey(typeof(Venue))]
        //public string VenueId { get; set; }
        //[OneToOne(CascadeOperations = CascadeOperation.All)]
        //public Venue Venue { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Events> Events { get; set; }

        //[ForeignKey(typeof(Distination))]
        //public string DistinationCategory { get; set; }


     


    }

    public class Meta
    {
        public int Code { get; set; }
        public string RequestId { get; set; }
    }

    public class Item
    {
        public int UnreadCount { get; set; }
    }

    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Type { get; set; }

        [ForeignKey(typeof(Item))]
        public string ItemId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Item Item { get; set; }

        [ForeignKey(typeof(Distination))]
        public int DistinationId { get; set; }
    }

    public class Filter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Key { get; set; }

        [ForeignKey(typeof(SuggestedFilters))]
        public int SuggestedFiltersId { get; set; }
    }

    public class SuggestedFilters
    {
        public string Header { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Filter> Filters { get; set; }
    }

    public class Ne
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Sw
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class SuggestedBounds
    {
        [ForeignKey(typeof(Ne))]
        public string NeId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Ne Ne { get; set; }

        [ForeignKey(typeof(Sw))]
        public string SwId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Sw Sw { get; set; }
    }

    public class Item3
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Summary { get; set; }
        public string Type { get; set; }
        public string ReasonName { get; set; }


        [ForeignKey(typeof(Reasons))]
        public int ReasonsId { get; set; }
    }

    public class Reasons
    {
        public int Count { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Item3> Items { get; set; }
    }

    public class Contact
    {
        public string Phone { get; set; }
        public string FormattedPhone { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string FacebookUsername { get; set; }
        public string FacebookName { get; set; }
    }

    //public class Location
    //{
    //    public string Address { get; set; }
    //    public string CrossStreet { get; set; }
    //    public double Lat { get; set; }
    //    public double Lng { get; set; }
    //    public int Distance { get; set; }
    //    public string Cc { get; set; }
    //    public string City { get; set; }
    //    public string State { get; set; }
    //    public string Country { get; set; }
    //   // public List<string> FormattedAddress { get; set; }
    //    public string PostalCode { get; set; }
    //}

    public class Icon
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

       // public string Id { get; set; }
        public string Name { get; set; }
        public string PluralName { get; set; }
        public string ShortName { get; set; }

        [ForeignKey(typeof(Icon))]
        public string IconId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Icon Icon { get; set; }


        public bool Primary { get; set; }

        [ForeignKey(typeof(Venue))]
        public int VenueId { get; set; }
    }

    public class Stats
    {
        public int CheckinsCount { get; set; }
        public int UsersCount { get; set; }
        public int TipCount { get; set; }
    }

    public class Hours
    {
        public bool IsOpen { get; set; }
        public bool IsLocalHoliday { get; set; }
        public string Status { get; set; }
    }

    public class Photo
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class User1
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        [ForeignKey(typeof(Photo))]
        public string PhotoId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Photo Photo { get; set; }
    }

    public class Item4
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
       // public string Id { get; set; }

        public int CreatedAt { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        [ForeignKey(typeof(User1))]
        public string User1Id { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public User1 User { get; set; }
        public string Visibility { get; set; }


        [ForeignKey(typeof(Group2))]
        public int Group2Id { get; set; }
    }

    public class Group2
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Type { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Item4> Items { get; set; }


        [ForeignKey(typeof(Photos))]
        public int PhotosId { get; set; }
    }

    public class Photos
    {
        public int Count { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Group2> Groups { get; set; }
    }

    public class HereNow
    {
        public int Count { get; set; }
        public string Summary { get; set; }
       // public List<object> Groups { get; set; }
    }

    public class Photo2
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class User2
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }


        [ForeignKey(typeof(Photo2))]
        public string Photo2Id { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Photo2 Photo { get; set; }
    }

    public class Item5
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //public string Id { get; set; }
        public int CreatedAt { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        [ForeignKey(typeof(User2))]
        public string User2Id { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public User2 User { get; set; }
        public string Visibility { get; set; }

        [ForeignKey(typeof(FeaturedPhotos))]
        public int FeaturedPhotosId { get; set; }
    }

    public class FeaturedPhotos
    {
        public int Count { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Item5> Items { get; set; }
    }

    public class Price
    {
        public int Tier { get; set; }
        public string Message { get; set; }
        public string Currency { get; set; }
    }

    public class Menu
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string Anchor { get; set; }
        public string Url { get; set; }
        public string MobileUrl { get; set; }
        public string ExternalUrl { get; set; }
    }

    public class VenuePage
    {
        public string Id { get; set; }
    }

    public class Provider
    {
        public string Name { get; set; }
    }

    public class Delivery
    {
        public string Id { get; set; }
        public string Url { get; set; }


        [ForeignKey(typeof(Provider))]
        public string ProviderId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Provider Provider { get; set; }
    }

    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(typeof(Contact))]
        public string ContactId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Contact Contact { get; set; }

        [ForeignKey(typeof(Location))]
        public string LocationId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Location Location { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Category> Categories { get; set; }
        public bool Verified { get; set; }


        [ForeignKey(typeof(Stats))]
        public string StatsId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Stats Stats { get; set; }
        public double Rating { get; set; }
        public string RatingColor { get; set; }
        public int RatingSignals { get; set; }


        [ForeignKey(typeof(Hours))]
        public string HoursId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Hours Hours { get; set; }


        [ForeignKey(typeof(Photos))]
        public string PhotosId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Photos Photos { get; set; }


        [ForeignKey(typeof(HereNow))]
        public string HereNowId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public HereNow HereNow { get; set; }


        [ForeignKey(typeof(FeaturedPhotos))]
        public string FeaturedPhotosId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public FeaturedPhotos FeaturedPhotos { get; set; }
        public string Url { get; set; }


        [ForeignKey(typeof(Price))]
        public string PriceId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Price Price { get; set; }
        public bool? AllowMenuUrlEdit { get; set; }
        public bool? HasMenu { get; set; }


        [ForeignKey(typeof(Menu))]
        public string MenuId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Menu Menu { get; set; }


        [ForeignKey(typeof(VenuePage))]
        public string VenuePageId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public VenuePage VenuePage { get; set; }
        public string StoreId { get; set; }


        [ForeignKey(typeof(Delivery))]
        public string DeliveryId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Delivery Delivery { get; set; }
        public bool Visiblity { get; set; }
        public bool IsFavourite { get; set; }

    }

    public class Likes
    {
        public int Count { get; set; }
     //   public List<object> Groups { get; set; }
        public string Summary { get; set; }
    }

    public class Todo
    {
        public int Count { get; set; }
    }

    public class Photo3
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class User3
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }



        [ForeignKey(typeof(Photo3))]
        public string Photo3Id { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Photo3 Photo { get; set; }
        public string Type { get; set; }
    }

    public class Source
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Photo4
    {
        public string Id { get; set; }
        public int CreatedAt { get; set; }


        [ForeignKey(typeof(Source))]
        public string SourceId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Source Source { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Visibility { get; set; }
    }

    public class Tip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

      //  public string Id { get; set; }
        public int CreatedAt { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string CanonicalUrl { get; set; }


        [ForeignKey(typeof(Likes))]
        public string LikesId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Likes Likes { get; set; }
        public bool LogView { get; set; }
        public int AgreeCount { get; set; }
        public int DisagreeCount { get; set; }
        public string LastVoteText { get; set; }

        [ForeignKey(typeof(Todo))]
        public string TodoId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Todo Todo { get; set; }


        [ForeignKey(typeof(User3))]
        public string User3Id { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public User3 User { get; set; }




        [ForeignKey(typeof(Photo4))]
        public string Photo4Id { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Photo4 Photo { get; set; }


        public string Photourl { get; set; }
        public string Url { get; set; }

        [ForeignKey(typeof(Item2))]
        public int Item2Id { get; set; }
    }

    public class Item2
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Reasons))]
        public string ReasonsId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Reasons Reasons { get; set; }


        [ForeignKey(typeof(Venue))]
        public string VenueId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Venue Venue { get; set; }



        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Tip> Tips { get; set; }
        public string ReferralId { get; set; }


        [ForeignKey(typeof(Group))]
        public int GroupId { get; set; }
    }

    public class Group
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Item2> Items { get; set; }

        [ForeignKey(typeof(Response))]
        public int ResponseId { get; set; }
    }

    public class Response
    {

        [ForeignKey(typeof(SuggestedFilters))]
        public string SuggestedFiltersId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public SuggestedFilters SuggestedFilters { get; set; }
        public string HeaderLocation { get; set; }
        public string HeaderFullLocation { get; set; }
        public string HeaderLocationGranularity { get; set; }
        public int TotalResults { get; set; }


        [ForeignKey(typeof(SuggestedBounds))]
        public string SuggestedBoundsId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public SuggestedBounds SuggestedBounds { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Group> Groups { get; set; }
    }

    
}
