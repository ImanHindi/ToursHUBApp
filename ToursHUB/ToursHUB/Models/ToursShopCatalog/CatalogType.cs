namespace ToursHUB.Models.ToursShopCatalog
{
    public class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}