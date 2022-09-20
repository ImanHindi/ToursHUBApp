using ToursHUB.Services.Basket;
using ToursHUB.Services.ToursShopCatalog;
using ToursHUB.Services.Dependency;
using ToursHUB.Services.FixUri;
using ToursHUB.Services.Identity;
using ToursHUB.Services.Location;
using ToursHUB.Services.Marketing;
using ToursHUB.Services.OpenUrl;
using ToursHUB.Services.Order;
using ToursHUB.Services.RequestProvider;
using ToursHUB.Services.Settings;
using ToursHUB.Services.User;
using ToursHUB.Services;
using System;
using System.Globalization;
using System.Reflection;
using TinyIoC;
using Xamarin.Forms;
using ToursHUB.ToursGuide.Services.LocalDb;
using ToursHUB.Services.Share;
using ToursHUB.Models.ToursGuide;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ToursHUB.Models.TourMedia;
using ToursHUB.Models.User;
using System.Collections.Generic;
using ToursHUB.Services.ToursGuide;

namespace ToursHUB.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseLocalDbService { get; set; }

        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();

            // View models
            _container.Register<BasketViewModel>();
            _container.Register<TourCatalogViewModel>();
            _container.Register<CheckoutViewModel>();
            _container.Register<LoginViewModel>();
            _container.Register<MainViewModel>();
            _container.Register<OrderDetailViewModel>();
            _container.Register<ProfileViewModel>();
            _container.Register<SettingsViewModel>();
            _container.Register<CampaignViewModel>();
            _container.Register<CampaignDetailsViewModel>();

            // Services
            _container.Register<INavigationService, NavigationService>().AsSingleton();
            _container.Register<IDialogService, DialogService>();
            _container.Register<IOpenUrlService, OpenUrlService>();
            _container.Register<IIdentityService, IdentityService>();
            _container.Register<IRequestProvider, RequestProvider>();
            _container.Register<IDbServices, DbServices>();
            _container.Register<IPhotoServices, PhotoServices>();
            _container.Register<IGeoLocatorService, GeoLocatorService>();
            //_container.Register<IDbServices<City>>();
            //_container.Register<IDbServices<Distination>>();
            //_container.Register<IDbServices<Favourites>>();
            //_container.Register<IDbServices<VedioID>>();
            //_container.Register<IDbServices<Event>>();

            //_container.Register<IDbServices<User>>();



            _container.Register<IDependencyService, Services.Dependency.DependencyService>();
            _container.Register<ISettingsService, SettingsService>().AsSingleton();
            _container.Register<IFixUriService, FixUriService>().AsSingleton();
            _container.Register<ILocationService, LocationService>().AsSingleton();
            _container.Register<ICatalogService, CatalogLocalDbService>().AsSingleton();
            _container.Register<IToursGuideService, ToursGuideLocalDbService>().AsSingleton();

            _container.Register<IBasketService, BasketLocalDbService>().AsSingleton();
            _container.Register<IOrderService, OrderLocalDbService>().AsSingleton();
            _container.Register<IUserService, UserLocalDbService>().AsSingleton();
            _container.Register<ICampaignService, CampaignLocalDbService>().AsSingleton();
        }

        public static void UpdateDependencies(bool useLocalDbServices)
        {
            // Change injected dependencies
            if (useLocalDbServices)
            {
                _container.Register<IToursGuideService, ToursGuideLocalDbService>().AsSingleton();

                _container.Register<ICatalogService, CatalogLocalDbService>().AsSingleton();
                _container.Register<IBasketService, BasketLocalDbService>().AsSingleton();
                _container.Register<IOrderService, OrderLocalDbService>().AsSingleton();
                _container.Register<IUserService, UserLocalDbService>().AsSingleton();
                _container.Register<ICampaignService, CampaignLocalDbService>().AsSingleton();

                UseLocalDbService = true;
            }
            else
            {
                _container.Register<IToursGuideService, ToursGuideService>().AsSingleton();

                _container.Register<ICatalogService, CatalogService>().AsSingleton();
                _container.Register<IBasketService, BasketService>().AsSingleton();
                _container.Register<IOrderService, OrderService>().AsSingleton();
                _container.Register<IUserService, UserService>().AsSingleton();
                _container.Register<ICampaignService, CampaignService>().AsSingleton();

                UseLocalDbService = false;
            }
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}