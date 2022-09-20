using ToursHUB.Models.User;
using System;
using System.Threading.Tasks;
using ToursHUB.ToursGuide.Services.LocalDb;
using System.Collections.ObjectModel;
using ToursHUB.Extensions;
using Xamarin.Forms;

namespace ToursHUB.Services.User
{
    public class UserLocalDbService : IUserService
    {

        IDbServices dbServices;
        UserInfo userInfo;
        public UserLocalDbService(IDbServices DbServices)
        {
            dbServices = DbServices;
        }

        private UserInfo LocalDbUserInfo = new UserInfo
        {
            Id = 1,
            FirstName = "Iman",
            LastName = "Hindi",
            Password = "646373",
            ConfirmedPassword = "646373",
            Email = "eng.eman.hindi@gmail.com",
            Birthday = DateTime.UtcNow,
            Gender = "Female",
            ProfileImage = { ImageSource = Device.RuntimePlatform != Device.UWP ? "ProfileImage.png" : "Assets/ProfileImage.png" },

            CardDetails = {
            Email = "eng.eman.hindi@gmail.com",
            EmailVerified = true,
            PhoneNumber = "00962797374869",
            PhoneNumberVerified = true,
            Address ="Amman",
            Street = "Street",
            ZipCode = "",
            Country = "Jordan",
            State = "Seattle",
            CardNumber = "378282246310005",
            CardHolder = "Jordanian Express",
            CardSecurityNumber = "4321" }
        };

        public async Task<UserInfo> GetUserInfoAsync(string authToken)
        {
           // await Task.Delay(500);

           //return LocalDbUserInfo;
            await dbServices.AddWithChildrenAsync(LocalDbUserInfo);
            userInfo = await dbServices.GetDataWithChildrenAsync<UserInfo>(LocalDbUserInfo.Id);
            return userInfo;
        }
        public async Task<UserInfo> UpdateUserInfoAsync(string authToken, UserInfo user)
        {
            await dbServices.UpdateWithChildrenAsync(user);
            userInfo = await dbServices.GetDataWithChildrenAsync<UserInfo>(user.Id);
            return user;

        }


    }
}