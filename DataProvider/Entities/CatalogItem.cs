using Microsoft.Identity.Client;

namespace DataProvider.Entities
{
    public class CatalogItem
    {
        public int Id { get; }

        public int CatalogBrandId { get; set; }

        public bool IsDeleted { get; set; }

        public int? Transaction { get; set; }

        public TransactionPurshared TransactionPurshared { get; set; }

        public CatalogBrand CatalogBrand { get; set; }

        //CatalogItem(CatalogBrand catalogBrand)
        //{
        //    this.CatalogBrand = catalogBrand;
        //    this.CatalogBrandId = catalogBrand.Id;
        //}
    }
}
