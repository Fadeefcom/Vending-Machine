using DataProvider.Entities;
using System.Diagnostics.Contracts;

namespace VendingMachine.Models
{
    public class CatalogItemViewModel
    {
        public CatalogBrand CatalogBrand { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public int Cost { get; set; }

        public bool Loading { get; set; }

        public bool Disabled { get; set; }

        public string Message { get; set; }

        public bool IsDeleted { get; set; }
    }
}
