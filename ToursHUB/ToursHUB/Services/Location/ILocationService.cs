using System.Threading.Tasks;

namespace ToursHUB.Services.Location
{    
    public interface ILocationService
    {
        Task UpdateUserLocation(ToursHUB.Models.Locations.Location newLocReq, string token);
    }
}