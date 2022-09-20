using System.Collections.Generic;
using ToursHUB.Models.Basket;

using ToursHUB.Models.ToursShopCatalog;
using ToursHUB.Models.Marketing;

namespace ToursHUB.Services.FixUri
{
    public interface IFixUriService
    {
        void FixCatalogItemPictureUri(IEnumerable<CatalogItem> catalogItems);
        void FixBasketItemPictureUri(IEnumerable<BasketItem> basketItems);
        void FixCampaignItemPictureUri(IEnumerable<CampaignItem> campaignItems);
    }
}
