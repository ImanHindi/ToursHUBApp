using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ToursHUB.Models.ToursGuide;

namespace ToursHUB.Services.ToursGuide
{
    public interface IToursGuideService
    {

        Task<ObservableCollection<Country>> GetCountriesAsync();

       // Task<ObservableCollection<Country>> FilterAsync(int catalogBrandId, int catalogTypeId);
        Task<ObservableCollection<City>> GetCitiesofSelectedCountryAsync(int CountryId);
        Task<ObservableCollection<Distination>> GetDistinationsofSelectedCityAsync(int CountryId, int CityId);


      //  Task<ObservableCollection<FoursquareVenues>> GetVenuesofSelectedDistinationAsync(int CountryId, int CityId, int DistinationId);

    }
}
