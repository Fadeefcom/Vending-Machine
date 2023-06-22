using DataProvider.Entities;

namespace DataProvider.Handler
{
    public interface IDataProvider
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(CancellationToken token);

        Task<CatalogItem> GetCatalogItemAsync(int id, CancellationToken token);
        
        Task<bool> PutGatalogItemAsync(CatalogItem value, CancellationToken token);

        Task<IEnumerable<CatalogBrand>> GetCatalogBrandsAsync(CancellationToken token);

        Task<CatalogBrand> GetCatalogBrandsAsync(int id, CancellationToken token);

        Task<bool> PutCatalogBrandAsync(CatalogBrand value, CancellationToken token);

        Task<bool> DeleteCatalogBrandAsync(CatalogBrand value, CancellationToken token);

        Task<CatalogBrand> UpdateCatalogBrandAsync(CatalogBrand value, CancellationToken token);

        Task<IEnumerable<ErrorDetail>> GetErrorDetailsAsync(CancellationToken token);

        Task<ErrorDetail> GetErrorDetailAsync(int id, CancellationToken token);

        Task<bool> PutErrorDetailAsync(ErrorDetail value, CancellationToken token);

        Task<IEnumerable<TransactionPurshared>> GetTransactionPursharedsAsync(CancellationToken token);

        Task<TransactionPurshared> GetTransactionPursharedAsync(int id, CancellationToken token);

        Task<bool> PutTransactionPursharedAsync(TransactionPurshared value, CancellationToken token);

        Task<IEnumerable<CoinType>> GetCointTypeAsync(CancellationToken token);

        Task<CoinType> GetCoinTypeAsync(int id, CancellationToken token);

        Task<bool> PutCoinTypeAsync(CoinType value, CancellationToken token);

        Task<bool> DeleteCoinTypeAsync(CoinType value, CancellationToken token);

        Task<CoinType> UpdateCoinTypeAsync(CoinType value, CancellationToken token);
    }
}
