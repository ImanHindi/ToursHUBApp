using ToursHUB.Models.User;
using System.Threading.Tasks;

namespace ToursHUB.Services.Identity
{
    public interface IIdentityService
    {
        string CreateAuthorizationRequest();
        string CreateLogoutRequest(string token);
        Task<UserToken> GetTokenAsync(string code);
    }
}