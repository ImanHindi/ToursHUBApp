using ToursHUB.Models.Locations;
using ToursHUB.Models.User;
using ToursHUB.Services.Location;
using ToursHUB.Services.Settings;
using ToursHUB.ViewModels.Base;
using Plugin.Geolocator;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToursHUB.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private string _titleUseWebApiServices;
        private string _descriptionUseWebApiServices;
        private bool _useWebApiServices;
        private string _titleUseFakeLocation;
        private string _descriptionUseFakeLocation;
        private bool _allowGpsLocation;
        private string _titleAllowGpsLocation;
        private string _descriptionAllowGpsLocation;
        private bool _useFakeLocation;
        private string _endpoint;
        private double _latitude;
        private double _longitude;
        private string _gpsWarningMessage;

        private readonly ISettingsService _settingsService;
        private readonly ILocationService _locationService;

        public SettingsViewModel(ISettingsService settingsService, ILocationService locationService)
        {
            _settingsService = settingsService;
            _locationService = locationService;

            _useWebApiServices = !_settingsService.UseLocalDb;
            _endpoint = _settingsService.UrlBase;
            _latitude = double.Parse(_settingsService.Latitude, CultureInfo.CurrentCulture);
            _longitude = double.Parse(_settingsService.Longitude, CultureInfo.CurrentCulture);
            //_useFakeLocation = _settingsService.UseFakeLocation;
            _useFakeLocation = false;

            _allowGpsLocation = _settingsService.AllowGpsLocation;
            _gpsWarningMessage = string.Empty;
        }

        public string TitleUseWebApiServices
        {
            get => _titleUseWebApiServices;
            set
            {
                _titleUseWebApiServices = value;
                RaisePropertyChanged(() => TitleUseWebApiServices);
            }
        }

        public string DescriptionUseWebApiServices
        {
            get => _descriptionUseWebApiServices;
            set
            {
                _descriptionUseWebApiServices = value;
                RaisePropertyChanged(() => DescriptionUseWebApiServices);
            }
        }

        public bool UseWebApiServices
        {
            get => _useWebApiServices;
            set
            {
                _useWebApiServices = value;

                UpdateUseWebApiServices();

                RaisePropertyChanged(() => UseWebApiServices);
            }
        }

        public string TitleUseFakeLocation
        {
            get => _titleUseFakeLocation;
            set
            {
                _titleUseFakeLocation = value;
                RaisePropertyChanged(() => TitleUseFakeLocation);
            }
        }

        public string DescriptionUseFakeLocation
        {
            get => _descriptionUseFakeLocation;
            set
            {
                _descriptionUseFakeLocation = value;
                RaisePropertyChanged(() => DescriptionUseFakeLocation);
            }
        }

        public bool UseFakeLocation
        {
            get => _useFakeLocation;
            set
            {
                _useFakeLocation = value;

                UpdateFakeLocation();

                RaisePropertyChanged(() => UseFakeLocation);
            }
        }

        public string TitleAllowGpsLocation
        {
            get => _titleAllowGpsLocation;
            set
            {
                _titleAllowGpsLocation = value;
                RaisePropertyChanged(() => TitleAllowGpsLocation);
            }
        }

        public string DescriptionAllowGpsLocation
        {
            get => _descriptionAllowGpsLocation;
            set
            {
                _descriptionAllowGpsLocation = value;
                RaisePropertyChanged(() => DescriptionAllowGpsLocation);
            }
        }

        public string GpsWarningMessage
        {
            get => _gpsWarningMessage;
            set
            {
                _gpsWarningMessage = value;
                RaisePropertyChanged(() => GpsWarningMessage);
            }
        }

        public string Endpoint
        {
            get => _endpoint;
            set
            {
                _endpoint = value;

                if (!string.IsNullOrEmpty(_endpoint))
                {
                    UpdateEndpoint();
                }

                RaisePropertyChanged(() => Endpoint);
            }
        }

        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;

                UpdateLatitude();

                RaisePropertyChanged(() => Latitude);
            }
        }

        public double Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;

                UpdateLongitude();

                RaisePropertyChanged(() => Longitude);
            }
        }

        public bool AllowGpsLocation
        {
            get => _allowGpsLocation;
            set
            {
                _allowGpsLocation = value;

                UpdateAllowGpsLocation();

                RaisePropertyChanged(() => AllowGpsLocation);
            }
        }

        public bool UserIsLogged => !string.IsNullOrEmpty(_settingsService.AuthAccessToken);

        public ICommand ToggleLocalDbServicesCommand => new Command(async () => await ToggleLocalDbServicesAsync());

        public ICommand ToggleFakeLocationCommand => new Command(ToggleFakeLocationAsync);

        public ICommand ToggleSendLocationCommand => new Command(async () => await ToggleSendLocationAsync());

        public ICommand ToggleAllowGpsLocationCommand => new Command(ToggleAllowGpsLocation);

        public override Task InitializeAsync(object navigationData)
        {
            UpdateInfoUseWebApiServices();
            UpdateInfoFakeLocation();
            UpdateInfoAllowGpsLocation();

            return base.InitializeAsync(navigationData);
        }

        private async Task ToggleLocalDbServicesAsync()
        {
            ViewModelLocator.UpdateDependencies(!UseWebApiServices);
            UpdateInfoUseWebApiServices();

            var previousPageViewModel = NavigationService.PreviousPageViewModel;
            if (previousPageViewModel != null)
            {
                if (previousPageViewModel is MainViewModel)
                {
                    // Slight delay so that page navigation isn't instantaneous
                    await Task.Delay(1000);
                    if (UseWebApiServices)
                    {
                        _settingsService.AuthAccessToken = string.Empty;
                        _settingsService.AuthIdToken = string.Empty;

                        await NavigationService.NavigateToAsync<LoginViewModel>(new LogoutParameter { Logout = true });
                        await NavigationService.RemoveBackStackAsync();
                    }
                }
            }
        }

        private void ToggleFakeLocationAsync()
        {
            ViewModelLocator.UpdateDependencies(!UseWebApiServices);
            UpdateInfoFakeLocation();
        }

        private async Task ToggleSendLocationAsync()
        {
            if (!_settingsService.UseLocalDb)
            {
                var locationRequest = new Location
                {
                    Latitude = _latitude,
                    Longitude = _longitude
                };
                var authToken = _settingsService.AuthAccessToken;

                await _locationService.UpdateUserLocation(locationRequest, authToken);
            }
        }

        private void ToggleAllowGpsLocation()
        {
            UpdateInfoAllowGpsLocation();
        }

        private void UpdateInfoUseWebApiServices()
        {
            if (!UseWebApiServices)
            {
                TitleUseWebApiServices = "Use LocalDatabase Services";
                DescriptionUseWebApiServices = "LocalDatabase Services is Used when the Network is weak or no wifi is available";
            }
            else
            {
                TitleUseWebApiServices = "Use WebApiServices from ToursHub";
                DescriptionUseWebApiServices = "When enabling the use WebApiServices from ToursHub(WiFi), the app will attempt to Update UR app Data Syncronously";
            }
        }

        private void UpdateInfoFakeLocation()
        {
            if (!UseFakeLocation)
            {
                TitleUseFakeLocation = "enable Location";
                DescriptionUseFakeLocation = "by enabling location, you can Navigate to your Current Location and get directions for your distination endpoint";

            }
            else
            {
                TitleUseFakeLocation = "Disable Location";
                DescriptionUseFakeLocation = "when Location Disabled, you Can't Navigate to your Current Location and get directions for your distination  ";
            }
        }

        private void UpdateInfoAllowGpsLocation()
        {
            if (!AllowGpsLocation)
            {
                TitleAllowGpsLocation = "GPS Location Disabled";
                DescriptionAllowGpsLocation = "When disabling location, you won't receive your Distination location based upon your location.";
            }
            else
            {
                TitleAllowGpsLocation = "GPS Location Enabled";
                DescriptionAllowGpsLocation = "When enabling location, you'll receive your Distination location  based upon your location.";

            }
        }


        private void UpdateUseWebApiServices()
        {
            // Save use LocalDbs services to local storage
            _settingsService.UseLocalDb = !_useWebApiServices;
        }

        private void UpdateEndpoint()
        {
            // Update remote endpoint (save to local storage)
            GlobalSetting.Instance.BaseEndpoint = _settingsService.UrlBase = _endpoint;
        }

        private void UpdateFakeLocation()
        {
            _settingsService.UseFakeLocation = _useFakeLocation;

        }

        private void UpdateLatitude()
        {
            // Update fake latitude (save to local storage)
            _settingsService.Latitude = _latitude.ToString();
        }

        private void UpdateLongitude()
        {
            // Update fake longitude (save to local storage)
            _settingsService.Longitude = _longitude.ToString();
        }

        private void UpdateAllowGpsLocation()
        {
            if (_allowGpsLocation)
            {
                var locator = CrossGeolocator.Current;
                if (!locator.IsGeolocationEnabled)
                {
                    _allowGpsLocation = false;
                    GpsWarningMessage = "Enable the GPS on your device";
                }
                else
                {
                    _settingsService.AllowGpsLocation = _allowGpsLocation;
                    GpsWarningMessage = string.Empty;
                }
            }
            else
            {
                _settingsService.AllowGpsLocation = _allowGpsLocation;
            }
        }
    }
}