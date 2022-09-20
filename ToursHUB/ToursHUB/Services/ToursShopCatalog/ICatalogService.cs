using ToursHUB.Models.ToursShopCatalog;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ToursHUB.Services.ToursShopCatalog
{
    public interface ICatalogService
    {
        Task<ObservableCollection<CatalogBrand>> GetCatalogBrandAsync();
        Task<ObservableCollection<CatalogItem>> FilterAsync(int catalogBrandId, int catalogTypeId);
        Task<ObservableCollection<CatalogType>> GetCatalogTypeAsync();
        Task<ObservableCollection<CatalogItem>> GetCatalogAsync();
    }
}
