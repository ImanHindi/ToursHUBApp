using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToursHUB.Models.User
{
    public class FacebookProfile
    {

        public string Name { get; set; }


        [ForeignKey(typeof(Picture))]
        public string PictureId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Picture Picture { get; set; }


        public string Locale { get; set; }
        public string Link { get; set; }

        [ForeignKey(typeof(Cover))]
        public string CoverId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Cover Cover { get; set; }



        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsVerified { get; set; }
        public string Id { get; set; }
    }

    public class Picture
    {
        public bool IsSilhouette { get; set; }
        public string Url { get; set; }
    }

   public class Cover
    {
        public string Id { get; set; }
        public int OffsetY { get; set; }
        public string Source { get; set; }
    }

   

}
