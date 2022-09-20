
using ToursHUB.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ToursHUB.Models.ToursShopCatalog;
using ToursHUB.Services.ToursShopCatalog;

namespace ToursHUB.ViewModels
{
    public class TourCatalogViewModel : ViewModelBase
    {
        private ObservableCollection<CatalogItem> _tours;
        private ObservableCollection<CatalogBrand> _brands;
        private CatalogBrand _brand;
        private ObservableCollection<CatalogType> _types;
        private CatalogType _type;
        private ICatalogService _toursService;

        public TourCatalogViewModel(ICatalogService toursService)
        {
            _toursService = toursService;
        }

        public ObservableCollection<CatalogItem> Tours
        {
            get { return _tours; }
            set
            {
                _tours = value;
                RaisePropertyChanged(() => Tours);
            }
        }

        public ObservableCollection<CatalogBrand> Brands
        {
            get { return _brands; }
            set
            {
                _brands = value;
                RaisePropertyChanged(() => Brands);
            }
        }

        public CatalogBrand Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                RaisePropertyChanged(() => Brand);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public ObservableCollection<CatalogType> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                RaisePropertyChanged(() => Types);
            }
        }

        public CatalogType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                RaisePropertyChanged(() => Type);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public bool IsFilter { get { return Brand != null || Type != null; } }

        public ICommand AddCatalogItemCommand => new Command<CatalogItem>(AddCatalogItem);

        public ICommand FilterCommand => new Command(async () => await FilterAsync());

		public ICommand ClearFilterCommand => new Command(async () => await ClearFilterAsync());

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            // Get Catalog, Brands and Types
            Tours = await _toursService.GetCatalogAsync();
            Brands = await _toursService.GetCatalogBrandAsync();
            Types = await _toursService.GetCatalogTypeAsync();

            IsBusy = false;
        }

        private void AddCatalogItem(CatalogItem catalogItem)
        {
            // Add new item to Basket
            MessagingCenter.Send(this, MessageKeys.AddTour, catalogItem);
        }

        private async Task FilterAsync()
        {
            if (Brand == null || Type == null)
            {
                return;
            }

            IsBusy = true;

            // Filter catalog tours
            MessagingCenter.Send(this, MessageKeys.Filter);
            Tours = await _toursService.FilterAsync(Brand.Id, Type.Id);

            IsBusy = false;
        }

        private async Task ClearFilterAsync()
        {
            IsBusy = true;

            Brand = null;
            Type = null;
            Tours = await _toursService.GetCatalogAsync();

            IsBusy = false;
        }
    }
}