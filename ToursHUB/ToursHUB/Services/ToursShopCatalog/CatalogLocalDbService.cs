using ToursHUB.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using ToursHUB.Models.ToursShopCatalog;

namespace ToursHUB.Services.ToursShopCatalog
{
    public class CatalogLocalDbService : ICatalogService
    {
        private ObservableCollection<CatalogBrand> LocalDbCatalogBrand = new ObservableCollection<CatalogBrand>
        {
            new CatalogBrand { Id = 1, Brand = "WadiRum" },
            new CatalogBrand { Id = 2, Brand = "Aqaba" }
        };

        private ObservableCollection<CatalogType> LocalDbCatalogType = new ObservableCollection<CatalogType>
        {
            new CatalogType { Id = 1, Type = "Mawakeb" },
            new CatalogType { Id = 2, Type = "Dallas" }
        };

        private ObservableCollection<CatalogItem> LocalDbCatalog = new ObservableCollection<CatalogItem>
        {
			new CatalogItem { Id = Common.Common.LocalDbCatalogItemId01, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_01.png" : "Assets/fake_tour_01.png", Name = "Nebo Mountain ", Price = 19.50M, CatalogBrandId = 2, CatalogBrand = "Mawakeb", CatalogTypeId = 2, CatalogType = "Intrnal Tours(Jordan)" },
			new CatalogItem { Id = Common.Common.LocalDbCatalogItemId02, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_02.png" : "Assets/fake_tour_02.png", Name = "Ajloun", Price = 19.50M, CatalogBrandId = 2, CatalogBrand = "Mawakeb", CatalogTypeId = 2, CatalogType = "Intrnal Tours(Jordan)" },
			new CatalogItem { Id = Common.Common.LocalDbCatalogItemId03, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_03.png" : "Assets/fake_tour_03.png", Name = "Aqapa", Price = 19.95M, CatalogBrandId = 2, CatalogBrand = "Mawakeb", CatalogTypeId = 2, CatalogType = "Intrnal Tours(Jordan)" },
			new CatalogItem { Id = Common.Common.LocalDbCatalogItemId04, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_04.png" : "Assets/fake_tour_04.png", Name = "Wadi Rum", Price = 17.00M, CatalogBrandId = 2, CatalogBrand = "Mawakeb", CatalogTypeId = 1, CatalogType = "Intrnal Tours(Jordan)" },
			new CatalogItem { Id = Common.Common.LocalDbCatalogItemId05, PictureUri = Device.RuntimePlatform != Device.UWP ? "fake_tour_05.png" : "Assets/fake_tour_05.png", Name = "DeadSea", Price = 19.50M, CatalogBrandId = 1, CatalogBrand = "Dallas", CatalogTypeId = 2, CatalogType = "Intrnal Tours(Jordan)" }
        };

        public async Task<ObservableCollection<CatalogItem>> GetCatalogAsync()
        {
            await Task.Delay(500);

            return LocalDbCatalog;
        }

        public async Task<ObservableCollection<CatalogItem>> FilterAsync(int catalogBrandId, int catalogTypeId)
        {
            await Task.Delay(500);

            return LocalDbCatalog
                .Where(c => c.CatalogBrandId == catalogBrandId &&
                c.CatalogTypeId == catalogTypeId)   
                .ToObservableCollection();
        }

        public async Task<ObservableCollection<CatalogBrand>> GetCatalogBrandAsync()
        {
            await Task.Delay(500);

            return LocalDbCatalogBrand;
        }

        public async Task<ObservableCollection<CatalogType>> GetCatalogTypeAsync()
        {
            await Task.Delay(500);

            return LocalDbCatalogType;
        }
    }
}