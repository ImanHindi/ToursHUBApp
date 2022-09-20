using ToursHUB.Models.Basket;
using ToursHUB.Models.Navigation;
using ToursHUB.Models.Orders;
using ToursHUB.Models.User;
using ToursHUB.Services.Basket;
using ToursHUB.Services.Order;
using ToursHUB.Services.Settings;
using ToursHUB.Services.User;
using ToursHUB.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ToursHUB.ViewModels;

namespace ToursHUB.ViewModels
{
    public class CheckoutViewModel : ViewModelBase
    {
        private ObservableCollection<BasketItem> _orderItems;
        private Order _order;
        private Address _shippingAddress;

        private ISettingsService _settingsService;
        private IBasketService _basketService;
        private IOrderService _orderService;
        private IUserService _userService;

        public CheckoutViewModel(
            ISettingsService settingsService,
            IBasketService basketService,
            IOrderService orderService,
            IUserService userService)
        {
            _settingsService = settingsService;
            _basketService = basketService;
            _orderService = orderService;
            _userService = userService;
        }

        public ObservableCollection<BasketItem> OrderItems
        {
            get { return _orderItems; }
            set
            {
                _orderItems = value;
                RaisePropertyChanged(() => OrderItems);
            }
        }

        public Order Order
        {
            get { return _order; }
            set
            {
                _order = value;
                RaisePropertyChanged(() => Order);
            }
        }

        public Address ShippingAddress
        {
            get { return _shippingAddress; }
            set
            {
                _shippingAddress = value;
                RaisePropertyChanged(() => ShippingAddress);
            }
        }

        public ICommand CheckoutCommand => new Command(async () => await CheckoutAsync());

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is ObservableCollection<BasketItem>)
            {
                IsBusy = true;

                // Get navigation data
                var orderItems = ((ObservableCollection<BasketItem>)navigationData);

                OrderItems = orderItems;

                var authToken = _settingsService.AuthAccessToken;
                var userInfo = await _userService.GetUserInfoAsync(authToken);

                // Create Shipping Address
                ShippingAddress = new Address
                {
                    Id = !string.IsNullOrEmpty(userInfo?.Id.ToString()) ? new Guid(userInfo.Id.ToString()) : Guid.NewGuid(),
                   Street = userInfo?.CardDetails.Street,
                    ZipCode = userInfo?.CardDetails.ZipCode,
                    State = userInfo?.CardDetails.State,
                    Country = userInfo?.CardDetails.Country,
                    City = userInfo?.CardDetails.Address
                };

                // Create Payment Info
                var paymentInfo = new PaymentInfo
                {
                    CardNumber = userInfo?.CardDetails.CardNumber,
                    CardHolderName = userInfo?.CardDetails.CardHolder,
                    CardType = new CardType { Id = 3, Name = "MasterCard" },
                    SecurityNumber = userInfo?.CardDetails.CardSecurityNumber
                };

                // Create new Order
                Order = new Order
                {
                    BuyerId = userInfo.Id.ToString(),
                    OrderItems = CreateOrderItems(orderItems),
                    OrderStatus = OrderStatus.Submitted,
                    OrderDate = DateTime.Now,
                    CardHolderName = paymentInfo.CardHolderName,
                    CardNumber = paymentInfo.CardNumber,
                    CardSecurityNumber = paymentInfo.SecurityNumber,
                    CardExpiration = DateTime.Now.AddYears(5),
                    CardTypeId = paymentInfo.CardType.Id,
                    ShippingState = _shippingAddress.State,
                    ShippingCountry = _shippingAddress.Country,
                    ShippingStreet = _shippingAddress.Street,
                    ShippingCity = _shippingAddress.City,
                    ShippingZipCode = _shippingAddress.ZipCode,
                    Total = CalculateTotal(CreateOrderItems(orderItems))
                };

                if (_settingsService.UseLocalDb)
                {
                    // Get number of orders
                    var orders = await _orderService.GetOrdersAsync(authToken);

                    // Create the OrderNumber
                    Order.OrderNumber = orders.Count + 1;
                    RaisePropertyChanged(() => Order);
                }

                IsBusy = false;
            }
        }

        private async Task CheckoutAsync()
        {
            try
            {
                var authToken = _settingsService.AuthAccessToken;

                var basket = _orderService.MapOrderToBasket(Order);
                basket.RequestId = Guid.NewGuid();

                // Create basket checkout
                await _basketService.CheckoutAsync(basket, authToken);

                if (_settingsService.UseLocalDb)
                {
                    await _orderService.CreateOrderAsync(Order, authToken);
                }

                // Clean Basket
                await _basketService.ClearBasketAsync(_shippingAddress.Id.ToString(), authToken);

                // Reset Basket badge
                var basketViewModel = ViewModelLocator.Resolve<BasketViewModel>();
                basketViewModel.BadgeCount = 0;

                // Navigate to Orders
                await NavigationService.NavigateToAsync<MainViewModel>(new TabParameter { TabIndex = 1 });
                await NavigationService.RemoveLastFromBackStackAsync();

                // Show Dialog
                await DialogService.ShowAlertAsync("Order sent successfully!", "Checkout", "Ok");
                await NavigationService.RemoveLastFromBackStackAsync();
            }
            catch
            {
                await DialogService.ShowAlertAsync("An error ocurred. Please, try again.", "Oops!", "Ok");
            }
        }

        private List<OrderItem> CreateOrderItems(ObservableCollection<BasketItem> basketItems)
        {
            var orderItems = new List<OrderItem>();

            foreach (var basketItem in basketItems)
            {
                if (!string.IsNullOrEmpty(basketItem.TourName))
                {
                    orderItems.Add(new OrderItem
                    {
                        OrderId = null,
                        TourId = basketItem.TourId,
                        TourName = basketItem.TourName,
                        PictureUrl = basketItem.PictureUrl,
                        Quantity = basketItem.Quantity,
                        UnitPrice = basketItem.UnitPrice
                    });
                }
            }

            return orderItems;
        }

        private decimal CalculateTotal(List<OrderItem> orderItems)
        {
            decimal total = 0;

            foreach (var orderItem in orderItems)
            {
                total += (orderItem.Quantity * orderItem.UnitPrice);
            }

            return total;
        }
    }
}