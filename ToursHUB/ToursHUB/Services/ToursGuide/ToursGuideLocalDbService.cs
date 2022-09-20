using ToursHUB.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using ToursHUB.ToursGuide.Services.LocalDb;
using ToursHUB.Models.ToursGuide;
using System.Collections.Generic;
using ToursHUB.Models.TourMedia;

namespace ToursHUB.Services.ToursGuide
{
    public class ToursGuideLocalDbService : IToursGuideService
    {
        private ObservableCollection<Country> CountriesLocalData = CountriesInfoList.CountriesInfo.ListToObservableCollection();
        private ObservableCollection<City> JordanCitiesLocalData = CitiesInfoList.JordanCitiesInfo.ListToObservableCollection();
        private ObservableCollection<Distination> DistinationsLocalData = DistinationsInfoList.DistinationsInfo.ListToObservableCollection();

        //private ObservableCollection<Venue> VenuesLocalData = VenuesInfoList.VenuesInfo.ListToObservableCollection();

        IDbServices dbServices;
        public ToursGuideLocalDbService(IDbServices DbServices)
        {
            dbServices = DbServices;
        }

        public async Task<ObservableCollection<Country>> GetCountriesAsync()
        {
            await dbServices.DeleteAllWithChildrenAsync(CountriesLocalData);
            await dbServices.AddAllWithChildrenAsync(CountriesLocalData);
            var countries = await dbServices.GetAllDataWithChildrenAsync<Country>();
            return countries;

        }

        public async Task<ObservableCollection<City>> GetCitiesofSelectedCountryAsync(int CountryId)
        {
            var country = await dbServices.GetDataWithChildrenAsync<Country>(CountryId);
            var cities = country.Cities.ListToObservableCollection();
            return cities;
        }

        public async Task<ObservableCollection<Distination>> GetDistinationsofSelectedCityAsync(int CountryId, int CityId)
        {
            var city = await dbServices.GetDataWithChildrenAsync<City>(CityId);
            var places = city.Distinations.ListToObservableCollection();
            return places;

        }

        //public async Task<ObservableCollection<FoursquareVenues>> GetVenuesofSelectedDistinationAsync(int CountryId, int CityId, int DistinationId)
        //{
        //    var place = await dbServices.GetDataWithChildrenAsync<Distination>(DistinationId);
            
        //    var venues = place.Venues.ListToObservableCollection();
        //    return venues;
        //}
    }
}















   //     private ObservableCollection<CatalogBrand> LocalDbCatalogBrand = new ObservableCollection<CatalogBrand>
   //     {
   //         new CatalogBrand { Id = 1, Brand = "WebApi" },
   //         new CatalogBrand { Id = 2, Brand = "Visual Studio" }
   //     };

   //     private ObservableCollection<CatalogType> LocalDbCatalogType = new ObservableCollection<CatalogType>
   //     {
   //         new CatalogType { Id = 1, Type = "Mug" },
   //         new CatalogType { Id = 2, Type = "T-Shirt" }
   //     };

   //     private ObservableCollection<CatalogItem> LocalDbCatalog = new ObservableCollection<CatalogItem>
   //     {
			//new CatalogItem { Id = Common.Common.LocalDbCatalogItemId01, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_01.png" : "Assets/fake_tour_01.png", Name = ".NET Bot Blue Sweatshirt (M)", Price = 19.50M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogTypeId = 2, CatalogType = "T-Shirt" },
			//new CatalogItem { Id = Common.Common.LocalDbCatalogItemId02, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_02.png" : "Assets/fake_tour_02.png", Name = ".NET Bot Purple Sweatshirt (M)", Price = 19.50M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogTypeId = 2, CatalogType = "T-Shirt" },
			//new CatalogItem { Id = Common.Common.LocalDbCatalogItemId03, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_03.png" : "Assets/fake_tour_03.png", Name = ".NET Bot Black Sweatshirt (M)", Price = 19.95M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogTypeId = 2, CatalogType = "T-Shirt" },
			//new CatalogItem { Id = Common.Common.LocalDbCatalogItemId04, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_04.png" : "Assets/fake_tour_04.png", Name = ".NET Black Cupt", Price = 17.00M, CatalogBrandId = 2, CatalogBrand = "Visual Studio", CatalogTypeId = 1, CatalogType = "Mug" },
			//new CatalogItem { Id = Common.Common.LocalDbCatalogItemId05, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_05.png" : "Assets/fake_tour_05.png", Name = "WebApi Black Sweatshirt (M)", Price = 19.50M, CatalogBrandId = 1, CatalogBrand = "WebApi", CatalogTypeId = 2, CatalogType = "T-Shirt" }
   //     };

    //    public async Task<ObservableCollection<CatalogItem>> GetCatalogAsync()
    //    {
    //        await Task.Delay(500);

    //        return LocalDbCatalog;
    //    }

    //    public async Task<ObservableCollection<CatalogItem>> FilterAsync(int catalogBrandId, int catalogTypeId)
    //    {
    //        await Task.Delay(500);

    //        return LocalDbCatalog
    //            .Where(c => c.CatalogBrandId == catalogBrandId &&
    //            c.CatalogTypeId == catalogTypeId)   
    //            .ToObservableCollection();
    //    }

    //    public async Task<ObservableCollection<CatalogBrand>> GetCatalogBrandAsync()
    //    {
    //        await Task.Delay(500);

    //        return LocalDbCatalogBrand;
    //    }

    //    public async Task<ObservableCollection<CatalogType>> GetCatalogTypeAsync()
    //    {
    //        await Task.Delay(500);

    //        return LocalDbCatalogType;
    //    }
    //}
//}