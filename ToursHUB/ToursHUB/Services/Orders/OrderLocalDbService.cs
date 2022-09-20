using ToursHUB.Extensions;
using ToursHUB.Models.Basket;
using ToursHUB.Models.Orders;
using ToursHUB.Models.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToursHUB.Services.Order
{
    public class OrderLocalDbService : IOrderService
    {
        private static DateTime LocalDbExpirationDate = DateTime.Now.AddYears(5);

        private static Address LocalDbAdress = new Address
        {
            Id = Guid.NewGuid(),
            City = "Seattle, WA",
            Street = "120 E 87th Street",
            CountryCode = "98122",
            Country = "United States",
            Latitude = 40.785091,
            Longitude = -73.968285,
            State = "Seattle",
            ZipCode = "98101"
        };

        private static PaymentInfo LocalDbPaymentInfo = new PaymentInfo
        {
            Id = Guid.NewGuid(),
            CardHolderName = "American Express",
            CardNumber = "378282246310005",
            CardType = new CardType
            {
                Id = 3,
                Name = "MasterCard"
            },
            Expiration = LocalDbExpirationDate.ToString(),
            ExpirationMonth = LocalDbExpirationDate.Month,
            ExpirationYear = LocalDbExpirationDate.Year,
            SecurityNumber = "123"
        };

        private List<Models.Orders.Order> LocalDbOrders = new List<Models.Orders.Order>()
        {
            new Models.Orders.Order { OrderNumber = 1, SequenceNumber = 123, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Submitted, OrderItems = LocalDbOrderItems, CardTypeId = LocalDbPaymentInfo.CardType.Id, CardHolderName = LocalDbPaymentInfo.CardHolderName, CardNumber = LocalDbPaymentInfo.CardNumber, CardSecurityNumber = LocalDbPaymentInfo.SecurityNumber, CardExpiration = new DateTime(LocalDbPaymentInfo.ExpirationYear, LocalDbPaymentInfo.ExpirationMonth, 1), ShippingCity = LocalDbAdress.City, ShippingState = LocalDbAdress.State, ShippingCountry = LocalDbAdress.Country, ShippingStreet = LocalDbAdress.Street, Total = 36.46M },
            new Models.Orders.Order { OrderNumber = 2, SequenceNumber = 132, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Paid, OrderItems = LocalDbOrderItems, CardTypeId = LocalDbPaymentInfo.CardType.Id, CardHolderName = LocalDbPaymentInfo.CardHolderName, CardNumber = LocalDbPaymentInfo.CardNumber, CardSecurityNumber = LocalDbPaymentInfo.SecurityNumber, CardExpiration = new DateTime(LocalDbPaymentInfo.ExpirationYear, LocalDbPaymentInfo.ExpirationMonth, 1), ShippingCity = LocalDbAdress.City, ShippingState = LocalDbAdress.State, ShippingCountry = LocalDbAdress.Country, ShippingStreet = LocalDbAdress.Street, Total = 36.46M },
            new Models.Orders.Order { OrderNumber = 3, SequenceNumber = 231, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Cancelled, OrderItems = LocalDbOrderItems, CardTypeId = LocalDbPaymentInfo.CardType.Id, CardHolderName = LocalDbPaymentInfo.CardHolderName, CardNumber = LocalDbPaymentInfo.CardNumber, CardSecurityNumber = LocalDbPaymentInfo.SecurityNumber, CardExpiration = new DateTime(LocalDbPaymentInfo.ExpirationYear, LocalDbPaymentInfo.ExpirationMonth, 1), ShippingCity = LocalDbAdress.City, ShippingState = LocalDbAdress.State, ShippingCountry = LocalDbAdress.Country, ShippingStreet = LocalDbAdress.Street, Total = 36.46M },
            new Models.Orders.Order { OrderNumber = 4, SequenceNumber = 131, OrderDate = DateTime.Now, OrderStatus = OrderStatus.Shipped, OrderItems = LocalDbOrderItems, CardTypeId = LocalDbPaymentInfo.CardType.Id, CardHolderName = LocalDbPaymentInfo.CardHolderName, CardNumber = LocalDbPaymentInfo.CardNumber, CardSecurityNumber = LocalDbPaymentInfo.SecurityNumber, CardExpiration = new DateTime(LocalDbPaymentInfo.ExpirationYear, LocalDbPaymentInfo.ExpirationMonth, 1), ShippingCity = LocalDbAdress.City, ShippingState = LocalDbAdress.State, ShippingCountry = LocalDbAdress.Country, ShippingStreet = LocalDbAdress.Street, Total = 36.46M }
        };

        private static List<OrderItem> LocalDbOrderItems = new List<OrderItem>()
        {
            new OrderItem { OrderId = Guid.NewGuid(), TourId = Common.Common.LocalDbCatalogItemId01, Discount = 15, TourName = ".NET Bot Blue Sweatshirt (M)", Quantity = 1, UnitPrice = 16.50M, PictureUrl = Device.RuntimePlatform != Device.UWP ? "fake_tour_01.png" : "Assets/fake_tour_01.png" },
            new OrderItem { OrderId = Guid.NewGuid(), TourId = Common.Common.LocalDbCatalogItemId03, Discount = 0, TourName = ".NET Bot Black Sweatshirt (M)", Quantity = 2, UnitPrice = 19.95M, PictureUrl = Device.RuntimePlatform != Device.UWP ? "fake_tour_03.png" : "Assets/fake_tour_03.png" }
        };

        private static BasketCheckout LocalDbBasketCheckout = new BasketCheckout()
        {
            CardExpiration = DateTime.UtcNow,
            CardHolderName = "FakeCardHolderName",
            CardNumber = "122333423224",
            CardSecurityNumber = "1234",
            CardTypeId = 1,
            City = "FakeCity",
            Country = "FakeCountry",
            ZipCode = "FakeZipCode",
            Street = "FakeStreet"
        };

        public async Task<ObservableCollection<Models.Orders.Order>> GetOrdersAsync(string token)
        {
            await Task.Delay(500);

            if (!string.IsNullOrEmpty(token))
            {
                return LocalDbOrders
                    .OrderByDescending(o => o.OrderNumber)
                    .ToObservableCollection();
            }
            else
                return new ObservableCollection<Models.Orders.Order>();
        }

        public async Task<Models.Orders.Order> GetOrderAsync(int orderId, string token)
        {
            await Task.Delay(500);

            if (!string.IsNullOrEmpty(token))
                return LocalDbOrders
                    .FirstOrDefault(o => o.OrderNumber.Equals(orderId));
            else
                return new Models.Orders.Order();
        }

        public async Task CreateOrderAsync(Models.Orders.Order newOrder, string token)
        {
            await Task.Delay(500);

            if (!string.IsNullOrEmpty(token))
            {
                LocalDbOrders.Add(newOrder);
            }
        }

        public BasketCheckout MapOrderToBasket(Models.Orders.Order order)
        {
            return LocalDbBasketCheckout;
        }

        public Task<bool> CancelOrderAsync(int orderId, string token)
        {
            return Task.FromResult(true);
        }
    }
}