namespace DataProvider.Entities
{
    public class CatalogBrand
    {
        public int Id { get; }

        public string Name { get; set; }

        public double Volume { get; set; }

        public double Cost { get; set; }

        public DateTime Created { get; } = DateTime.Now;

        public ICollection<CatalogItem> CatalogItems { get; set; } = new List<CatalogItem>();
    }
}
