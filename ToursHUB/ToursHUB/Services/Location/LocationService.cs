using System;
using System.Threading.Tasks;
using ToursHUB.Services.RequestProvider;

namespace ToursHUB.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly IRequestProvider _requestProvider;

        public LocationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task UpdateUserLocation(ToursHUB.Models.Locations.Location newLocReq, string token)
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.LocationEndpoint);

            builder.Path = "api/v1/locations";

            string uri = builder.ToString();

            await _requestProvider.PostAsync(uri, newLocReq, token);
        }
    }
}