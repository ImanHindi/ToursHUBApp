using ToursHUB.Models.User;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ToursHUB.Services.User
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string authToken);
        //Task<Favourites> GetFavouritesofUserInfoAsync(string authToken);
        //Task<MyTrips> GetTripsofUserInfoAsync(string authToken);
        Task<UserInfo> UpdateUserInfoAsync(string authToken, UserInfo user);
    }
}
