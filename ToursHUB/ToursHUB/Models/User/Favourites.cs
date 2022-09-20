using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using ToursHUB.Models.TourMedia;
using ToursHUB.Models.ToursGuide;
using ToursHUB.Models.ToursShopCatalog;

namespace ToursHUB.Models.User
{
  public  class Favourite
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        //public List<Country> FavCountries { get; set; }
        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        //public List<City> FavCities { get; set; }
        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        //public List<Distination> FavDistinations { get; set; }

        //[OneToMany(CascadeOperations = CascadeOperation.All)]
        //public List<FoursquareVenues> FavVenues { get; set; }

        //[OneToMany(CascadeOperations = CascadeOperation.All)]

        //public List<CatalogItem> FavCatalogItem { get; set; }

        //[OneToMany(CascadeOperations = CascadeOperation.All)]

        //public List<Favourite> Favourites { get; set; }
        //public string Name { get; set; }

        //public string Category { get; set; }

        //public string Details { get; set; }

        //[ForeignKey(typeof(Image))]
        //public string ImageId { get; set; }
        //[OneToOne(CascadeOperations = CascadeOperation.All)]
        //public Image Image { get; set; }

        public Country FavCountry { get; set; }
        public City FavCity { get; set; }
        public Distination FavDistination { get; set; }
       // public FoursquareVenues FavVenues { get; set; }
        public CatalogItem FavCatalogItem { get; set; }

        [ForeignKey(typeof(UserInfo))]
        public int UserId { get; set; }

        //public int Count
        //{
        //    get
        //    {
        //        return Count;
        //    }
        //    set
        //    {
        //        Count = Favourites.Count;
        //    }
        //}

    }
    //public class Favourite
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int Id { get; set; }
    //    [OneToOne(CascadeOperations = CascadeOperation.All)]
      //  [OneToOne(CascadeOperations = CascadeOperation.All)]
      //  [OneToOne(CascadeOperations = CascadeOperation.All)]

      //  [OneToOne(CascadeOperations = CascadeOperation.All)]
      //  [OneToOne(CascadeOperations = CascadeOperation.All)]
   // }
    
}
