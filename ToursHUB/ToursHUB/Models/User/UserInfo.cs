using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using ToursHUB.Models.Locations;
using ToursHUB.Models.TourMedia;

namespace ToursHUB.Models.User
{
    public class UserInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; internal set; }

        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }

        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; internal set; }
        public bool PhoneNumberVerified { get; internal set; }

        [ForeignKey(typeof(FacebookProfile))]
        public string FacebookProfileId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public FacebookProfile FacebookProfile { get; set; }


        [ForeignKey(typeof(Image))]
        public string ImageId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Image ProfileImage { get; set; }



       

        [ForeignKey(typeof(Location))]
        public string LocationId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Location CurrentLocation { get; set; }

        public string CurrentLat { get; set; }
        public string CurrentLong { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Favourite> Favourites { get; set; }

        public List<MyTrips> MyTrips { get; set; }

        public Card CardDetails { get; set; }
        
    }
}
