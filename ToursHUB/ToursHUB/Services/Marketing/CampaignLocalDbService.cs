using ToursHUB.Models.Marketing;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToursHUB.Services.Marketing
{
    public class CampaignLocalDbService : ICampaignService
    {
        private readonly ObservableCollection<CampaignItem> _LocalDbCampaign = new ObservableCollection<CampaignItem>
        {
            new CampaignItem
            {
                Id = Common.Common.LocalDbCampaignId01,
                PictureUri = Device.RuntimePlatform != Device.UWP
                    ? "fake_campaign_01.png"
                    : "Assets/fake_campaign_01.png",
                Name = ".NET Bot Black Hoodie 50% OFF",
                Description = "Campaign Description 1",
                From = DateTime.Now,
                To = DateTime.Now.AddDays(7)
            },

            new CampaignItem
            {
                Id = Common.Common.LocalDbCampaignId02,
                PictureUri = Device.RuntimePlatform != Device.UWP
                    ? "fake_campaign_02.png"
                    : "Assets/fake_campaign_02.png",
                Name = "Roslyn Red T-Shirt 3x2",
                Description = "Campaign Description 2",
                From = DateTime.Now.AddDays(-7),
                To = DateTime.Now.AddDays(14)
            }
        };

        public async Task<ObservableCollection<CampaignItem>> GetAllCampaignsAsync(string token)
        {
            await Task.Delay(500);
            return _LocalDbCampaign;
        }

        public async Task<CampaignItem> GetCampaignByIdAsync(int campaignId, string token)
        {
            await Task.Delay(500);
            return _LocalDbCampaign.SingleOrDefault(c => c.Id == campaignId);
        }
    }
}