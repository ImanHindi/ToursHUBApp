using System;
using Xamarin.Forms;

namespace ToursHUB.Models.Basket
{
    public class BasketItem : BindableObject
    {
        private int _quantity;


        public string Id { get; set; }
       
        public string TourId { get; set; }

        public string TourName { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


        public decimal UnitPrice { get; set; }

        public decimal OldUnitPrice { get; set; }

        public bool HasNewPrice
        {
            get
            {
                return OldUnitPrice != 0.0m;
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public string PictureUrl { get; set; }

        public decimal Total { get { return Quantity * UnitPrice; } }

        public override string ToString()
        {
            return String.Format("Tour Id: {0}, Quantity: {1}", TourId, Quantity);
        }
    }
}