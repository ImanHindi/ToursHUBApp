using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ToursHUB.Extensions;
using ToursHUB.Models.ToursGuide;
using ToursHUB.Services.FixUri;
using ToursHUB.Services.RequestProvider;

namespace ToursHUB.Services.ToursGuide
{
    public class ToursGuideService : IToursGuideService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;

        public ToursGuideService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }
        public async Task<ObservableCollection<City>> GetCitiesofSelectedCountryAsync(int CountryId)
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.ToursGuideCatalogEndpoint);
            builder.Path = string.Format("api/ToursGuideCatalog/CountryInfoModels/{0}/CityInfoModels", CountryId);
            string uri = builder.ToString();

            IEnumerable<City> SelectedCountryCities = await _requestProvider.GetAsync <IEnumerable<City>> (uri);

            if (SelectedCountryCities != null)
                return SelectedCountryCities?.ToObservableCollection();
            else
                return new ObservableCollection<City>();


        }

        public async Task<ObservableCollection<Country>> GetCountriesAsync()
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.ToursGuideCatalogEndpoint);
            builder.Path = "api/ToursGuideCatalog/CountryInfoModels";
            string uri = builder.ToString();

            IEnumerable<Country> Countries = await _requestProvider.GetAsync<IEnumerable<Country>>(uri);

            if (Countries != null)
                return Countries?.ToObservableCollection();
            else
                return new ObservableCollection<Country>();

        }

        public async Task<ObservableCollection<Distination>> GetDistinationsofSelectedCityAsync(int CountryId,int CityId)
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.ToursGuideCatalogEndpoint);
            builder.Path = string.Format("api/ToursGuideCatalog/CountryInfoModels/{0}/CityInfoModels/{1}/DistinationInfoModels", CountryId, CityId);
            string uri = builder.ToString();

            IEnumerable<Distination> SelectedCityDistinations = await _requestProvider.GetAsync<IEnumerable<Distination>>(uri);

            if (SelectedCityDistinations != null)
                return SelectedCityDistinations?.ToObservableCollection();
            else
                return new ObservableCollection<Distination>();
        }

        //public async Task<ObservableCollection<FoursquareVenues>> GetVenuesofSelectedDistinationAsync(int CountryId,int CityId,int DistinationId)
        //{
        //    UriBuilder builder = new UriBuilder(GlobalSetting.Instance.ToursGuideCatalogEndpoint);
        //    builder.Path = string.Format("api/ToursGuideCatalog/CountryInfoModels/{0}/CityInfoModels/{1}/DistinationInfoModels{2}/VenueInfoModels", CountryId, CityId, DistinationId);
        //    string uri = builder.ToString();

        //    IEnumerable<FoursquareVenues> SelectedCityDistinations = await _requestProvider.GetAsync<IEnumerable<FoursquareVenues>>(uri);

        //    if (SelectedCityDistinations != null)
        //        return SelectedCityDistinations?.ToObservableCollection();
        //    else
        //        return new ObservableCollection<FoursquareVenues>();

        //}
    }
}
