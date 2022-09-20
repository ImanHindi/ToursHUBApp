using ToursHUB.Models.Basket;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace ToursHUB.Services.Basket
{
    public class BasketLocalDbService : IBasketService
    {
        private CustomerBasket LocalDbCustomBasket = new CustomerBasket
        {
            BuyerId = "9245fe4a-d402-451c-b9ed-9c1a04247482",
            Items = new List<BasketItem>
                {
				new BasketItem { Id = "1", PictureUrl = Device.RuntimePlatform != Device.UWP ? "fake_tour_01.png" : "Assets/fake_tour_01.png", TourId = Common.Common.LocalDbCatalogItemId01, TourName = ".NET Bot Blue Sweatshirt (M)", Quantity = 1, UnitPrice = 19.50M },
				new BasketItem { Id = "2", PictureUrl = Device.RuntimePlatform != Device.UWP ? "fake_tour_04.png" : "Assets/fake_tour_04.png", TourId = Common.Common.LocalDbCatalogItemId04, TourName = ".NET Black Cupt", Quantity = 1, UnitPrice = 17.00M }
                }
        };

        public async Task<CustomerBasket> GetBasketAsync(string guidUser, string token)
        {
            await Task.Delay(500);

            if(string.IsNullOrEmpty(guidUser) || string.IsNullOrEmpty(token))
            {
                return new CustomerBasket();
            }

            return LocalDbCustomBasket;
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket, string token)
        {
            await Task.Delay(500);

            if (string.IsNullOrEmpty(token))
            {
                return new CustomerBasket();
            }

            LocalDbCustomBasket = customerBasket;

            return LocalDbCustomBasket;
        }

        public async Task ClearBasketAsync(string guidUser, string token)
        {
            await Task.Delay(500);

            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            if (!string.IsNullOrEmpty(guidUser))
            {
                LocalDbCustomBasket.Items.Clear();
            }
        }

        public Task CheckoutAsync(BasketCheckout basketCheckout, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return Task.FromResult(0);
            }

            if (basketCheckout != null)
            {
                LocalDbCustomBasket.Items.Clear();
            }

            return Task.FromResult(0);
        }
    }
}