using Newtonsoft.Json;
using System;

namespace ToursHUB.Models.Orders
{
    public class OrderItem
    {
        public string TourId { get; set; }
        public Guid? OrderId { get; set; }

        [JsonProperty("unitprice")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("tourname")]
        public string TourName { get; set; }

        [JsonProperty("pictureurl")]
        public string PictureUrl { get; set; }

        [JsonProperty("units")]
        public int Quantity { get; set; }

        public decimal Discount { get; set; }
        public decimal Total { get { return Quantity * UnitPrice; } }

        public override string ToString()
        {
            return String.Format("Tour Id: {0}, Quantity: {1}", TourId, Quantity);
        }
    }
}