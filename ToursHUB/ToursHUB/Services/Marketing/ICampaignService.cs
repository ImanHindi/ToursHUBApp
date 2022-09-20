using ToursHUB.Models.Marketing;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ToursHUB.Services.Marketing
{
    public interface ICampaignService
    {
        Task<ObservableCollection<CampaignItem>> GetAllCampaignsAsync(string token);
        Task<CampaignItem> GetCampaignByIdAsync(int id, string token);
    }
}