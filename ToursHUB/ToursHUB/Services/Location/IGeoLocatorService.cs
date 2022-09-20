using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToursHUB.Models;
using ToursHUB.Models.User;

namespace ToursHUB.Services
{
    public interface IGeoLocatorService
    {
        Task<Position> GetCurrentLocation();

        Task<double> GetCurrentLongitude();

        Task<double> GetCurrentLatitude();

        Task StartListening();

        Task StopListening();
    }
}
