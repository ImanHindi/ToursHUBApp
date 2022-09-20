using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace ToursHUB.Models.User
{
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public object Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

        public string CountryCode { get; set; }

        public string ZipCode { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Localized_Address_Display { get; set; }
    }
}
