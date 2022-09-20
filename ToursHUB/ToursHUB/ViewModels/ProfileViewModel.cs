using ToursHUB.Extensions;
using ToursHUB.Models.Orders;
using ToursHUB.Models.User;
using ToursHUB.Services.Order;
using ToursHUB.Services.Settings;
using ToursHUB.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ToursHUB.Services.User;
using Plugin.Media.Abstractions;
using ToursHUB.Services.Share;
using ToursHUB.Validations;

namespace ToursHUB.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;

        private readonly IOrderService _orderService;
        private ObservableCollection<Order> _orders;

        private readonly IUserService _userService;
        private UserInfo _user;
        private ObservableCollection<Favourite> _favourites;
        private ObservableCollection<MyTrips> _trips;
        private readonly IPhotoServices _photoServices;
        private bool _visiblity=false;
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;
        private bool _isValid;
        public ProfileViewModel(ISettingsService settingsService, IOrderService orderService, IUserService userService, IPhotoServices photoServices)
        {
            _settingsService = settingsService;
            _orderService = orderService;
            _userService = userService;
            _photoServices = photoServices;
            _visiblity = false;
            _userName = new ValidatableObject<string>();
           
            _password = new ValidatableObject<string>();
            AddValidations();
           
        }

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                RaisePropertyChanged(() => Orders);
            }
        }

        public UserInfo User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }

        public ObservableCollection<Favourite> Favourites
        {
            get { return _favourites; }
            set
            {
                _favourites = value;
                RaisePropertyChanged(() => Favourites);
            }
        }

        public ObservableCollection<MyTrips> Trips
        {
            get { return _trips; }
            set
            {
                _trips = value;
                RaisePropertyChanged(() => Trips);
            }
        }

        public bool Visiblity
        {
            get => _visiblity;
            set
            {
                _visiblity = value;


                RaisePropertyChanged(() => Visiblity);
            }
        }

        public ValidatableObject<string> UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public ValidatableObject<string> Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }
        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());

        public ICommand CreatTripCommand => new Command(async () => await CreatTripAsync());

        
        public ICommand ChangeProfileImageCommand => new Command(async () => await ChangeProfileImageAsync());

        public ICommand OrderDetailCommand => new Command<Order>(async (order) => await OrderDetailAsync(order));

        public ICommand EditUserInfoCommand => new Command<UserInfo>(async (user) => await EditUserInfoAsync(user));
        public ICommand TripDetailCommand => new Command<Trip>(async (mytrip) => await TripDetailAsync(mytrip));
        public ICommand FavouriteDetailCommand => new Command<Favourite>(async (favourite) => await FavouriteDetailAsync(favourite));

        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            // Get orders
            var authToken = _settingsService.AuthAccessToken;
            var orders = await _orderService.GetOrdersAsync(authToken);
            Orders = orders.ToObservableCollection();
            // Get User
            var user = await _userService.GetUserInfoAsync(authToken);
            User = user;
            // Get Favourites
            var favourites = user.Favourites.ToObservableCollection();
            Favourites = favourites;
            // Get Trips
            var trips = user.MyTrips.ToObservableCollection();
            Trips = trips;
            IsBusy = false;

            _userName.Value = user.Email;
            _password.Value = user.Password;
        }

        private async Task LogoutAsync()
        {
            IsBusy = true;

            // Logout
            await NavigationService.NavigateToAsync<LoginViewModel>(new LogoutParameter { Logout = true });
            await NavigationService.RemoveBackStackAsync();

            IsBusy = false;
        }

        private async Task OrderDetailAsync(Order order)
        {
            await NavigationService.NavigateToAsync<OrderDetailViewModel>(order);
        }


        private async Task CreatTripAsync()
        {
            await NavigationService.NavigateToAsync<CreatorEditTripViewModel>();
        }

        private async Task EditUserInfoAsync(UserInfo user)
        {
            //  await NavigationService.NavigateToAsync<EditUserInfoViewModel>(user);
           
            user.Email = _userName.Value;
            user.Password = _password.Value;
            User = user;
            var authToken = _settingsService.AuthAccessToken;
            await _userService.UpdateUserInfoAsync(authToken, user);
        }

        private async Task FavouriteDetailAsync(Favourite favourite)
        {
            await NavigationService.NavigateToAsync<TourGuideDetailViewModel>(favourite);
        }

        private async Task TripDetailAsync(Trip myTrip)
        {
            await NavigationService.NavigateToAsync<TourDetailViewModel>(myTrip);
        }

        private async Task ChangeProfileImageAsync()
        {
            // await NavigationService.NavigateToAsync<OrderDetailViewModel>(user);
            MediaFile file = await _photoServices.PickPhotoButton();
            User.ProfileImage.ImageSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();

                return stream;
            });
            var authToken = _settingsService.AuthAccessToken;
             await _userService.UpdateUserInfoAsync(authToken, _user);
        }
        //private void UpdateVisiblity()
        //{
        //    // Save use LocalDbs services to local storage
        //    Visiblity = !_visiblity;
        //}
        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();

            return isValidUser && isValidPassword;
        }

        private bool ValidateUserName()
        {
            return _userName.Validate();
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
        }

    }
}