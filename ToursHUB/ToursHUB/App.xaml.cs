using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToursHUB.Models.Locations;
using ToursHUB.Models.ToursGuide;
using ToursHUB.Models.User;
using ToursHUB.Services;
using ToursHUB.Services.Location;
using ToursHUB.Services.Settings;
using ToursHUB.Services.ToursGuide.LocalDb.BaseConnection;
using ToursHUB.ToursGuide.Services.LocalDb;
using ToursHUB.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToursHUB
{

	public partial class App : Application
	{
        ISettingsService _settingsService;
        IGeoLocatorService _geoLocatorService;

        public static IDbServices dbServices;
        //public static readonly string FileName = "ToursHUB.db3";
        public App ()
		{
			InitializeComponent();
            InitApp();
            if (Device.RuntimePlatform == Device.UWP)
            {
                InitNavigation();
            }
            InitDbServices();
            //     var unityContainer = new UnityContainer();


            //unityContainer.RegisterType<INavigationService, NavigationService>();
            //unityContainer.RegisterType<IEventbriteService, EventbriteService>();
            //unityContainer.RegisterType<ICitiesApiServices, CitiesApiServices>();
            //unityContainer.RegisterType<IFacebookServices, FacebookServices>();
            //unityContainer.RegisterType<ICitiesInfoDatabaseService, CitiesInfoDatabaseService>();
            //unityContainer.RegisterType<IDistinationsInfoDatabaseService, DistinationsInfoDatabaseService>();
            //unityContainer.RegisterType<ICountriesInfoDatabaseService, CountriesInfoDatabaseService>();
            //unityContainer.RegisterType<IPhotoServices, PhotoServices>();

            //unityContainer.RegisterType<IUserInfoDatabaseService, UserInfoDatabaseService>();
            //unityContainer.RegisterType<IGeoLocatorService, GeoLocatorService>();
            //unityContainer.RegisterType<IFoursquareService, FoursquareServices>();


            //unityContainer.RegisterInstance(typeof(EventbriteViewModel));
            //unityContainer.RegisterInstance(typeof(NavigationCommand));
            //unityContainer.RegisterInstance(typeof(YoutubeViewModel));
            //unityContainer.RegisterInstance(typeof(CitiesViewModel));
            //unityContainer.RegisterInstance(typeof(AddCityViewModel));
            //unityContainer.RegisterInstance(typeof(EditCityViewModel));
            //unityContainer.RegisterInstance(typeof(SearchViewModel));
            //unityContainer.RegisterInstance(typeof(RegisterViewModel));
            //unityContainer.RegisterInstance(typeof(MainViewModels));
            //unityContainer.RegisterInstance(typeof(LoginViewModel));
            //unityContainer.RegisterInstance(typeof(FacebookViewModel));
            //unityContainer.RegisterInstance(typeof(CountriesViewModel));
            //unityContainer.RegisterInstance(typeof(DistinationsViewModel));
            //unityContainer.RegisterInstance(typeof(SelectionViewModel));

            //unityContainer.RegisterInstance(typeof(UserAcountViewModel));




            //var unityServiceLocator = new UnityServiceLocator(unityContainer);
            //ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

            // MainPage = new ToursHUB.MainPage();
        }

        private void InitApp()
        {
            _settingsService = ViewModelLocator.Resolve<ISettingsService>();
            _geoLocatorService= ViewModelLocator.Resolve<IGeoLocatorService>();
            if (!_settingsService.UseLocalDb)
                ViewModelLocator.UpdateDependencies(_settingsService.UseLocalDb);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }
        private async Task<IDbServices> InitDbServices()
        {
            var dbServices = ViewModelLocator.Resolve<IDbServices>();
            await Task.Delay(500);
            DbServices = dbServices;
            return DbServices;
        }
        public  IDbServices DbServices
       {
            get
            {
                return dbServices;
            }
            set
            {
                dbServices = value;

            }
          
          
       }
          
        //public async Task CreatDbTables()
        //{
        //    await _GetDbConnectionAsync.CreatToursHubDbTables();
        //}

        protected override async void OnStart()
        {
            base.OnStart();

            if (Device.RuntimePlatform != Device.UWP)
            {
                await InitNavigation();
            }

            if (_settingsService.AllowGpsLocation && !_settingsService.UseFakeLocation)
            {
                await GetGpsLocation();
            }

            if (!_settingsService.UseLocalDb && !string.IsNullOrEmpty(_settingsService.AuthAccessToken))
            {
                await SendCurrentLocation();
            }

            base.OnResume();
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}


        private async Task GetGpsLocation()
        {
            //var locator = CrossGeolocator.Current;

            //if (locator.IsGeolocationEnabled && locator.IsGeolocationAvailable)
            //{
            //   // locator.AllowsBackgroundUpdates = true;
               // locator.DesiredAccuracy = 50;

                var position = await _geoLocatorService.GetCurrentLocation();

                _settingsService.Latitude = position.Latitude.ToString();
                _settingsService.Longitude = position.Longitude.ToString();
           // }
            //else
            //{
            //    _settingsService.AllowGpsLocation = true;
            //}
        }

        private async Task SendCurrentLocation()
        {
            var location = new Location
            {
               // Latitude = double.Parse(_settingsService.Latitude, CultureInfo.InvariantCulture),
                Latitude = await _geoLocatorService.GetCurrentLatitude(),
               // Longitude = double.Parse(_settingsService.Longitude, CultureInfo.InvariantCulture)
                Longitude = await _geoLocatorService.GetCurrentLongitude(),

            };

            var locationService = ViewModelLocator.Resolve<ILocationService>();
            await locationService.UpdateUserLocation(location, _settingsService.AuthAccessToken);
        }
    }
}
