using DataProvider;
using DataProvider.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataProvider.Handler
{
    public class FailHandler : IDataProvider
    {
        private readonly IServiceScopeFactory _scopefactory;

        private readonly ILoggerFactory _loggerFactory;

        private readonly ILogger<FailHandler> _logger;

        public FailHandler(BaseArguments args)
        {
            _scopefactory = args.scopefactory;
            _loggerFactory = args.loggerFactory;

            _logger = _loggerFactory.CreateLogger<FailHandler>();
        }

        public Task<bool> DeleteCatalogBrandAsync(CatalogBrand value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                _logger.LogInformation("Database failures. {0} for {1}", "DeleteCatalogBrandAsync", value.Id);
            }
            return Task.FromResult(false);
        }

        public Task<bool> DeleteCoinTypeAsync(CoinType value, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogBrand>> GetCatalogBrandsAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                _logger.LogInformation("Database failures. {0}", "GetCatalogBrandsAsync");
            }
            return Task.FromResult<IEnumerable<CatalogBrand>>(Array.Empty<CatalogBrand>());
        }

        public Task<CatalogBrand> GetCatalogBrandsAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogItem> GetCatalogItemAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                _logger.LogInformation("Database failures. {0}", "GetCatalogItemsAsync");
            }
            return Task.FromResult<IEnumerable<CatalogItem>>(Array.Empty<CatalogItem>());
        }

        public Task<IEnumerable<CoinType>> GetCointTypeAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                _logger.LogInformation("Database failures. {0}", "GetCointTypeAsync");
            }
            return Task.FromResult<IEnumerable<CoinType>>(Array.Empty<CoinType>());
        }

        public Task<CoinType> GetCoinTypeAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorDetail> GetErrorDetailAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ErrorDetail>> GetErrorDetailsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionPurshared> GetTransactionPursharedAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionPurshared>> GetTransactionPursharedsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutCatalogBrandAsync(CatalogBrand value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                _logger.LogInformation("Database failures. {0}. Existing name in DB", "PutCatalogBrandAsync");
            }
            return Task.FromResult(false);
        }

        public Task<bool> PutCoinTypeAsync(CoinType value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                _logger.LogInformation("Database failures. {0}. Existing name in DB", "PutCoinTypeAsync");
            }
            return Task.FromResult(false);
        }

        public Task<bool> PutErrorDetailAsync(ErrorDetail value, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutGatalogItemAsync(CatalogItem value, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutTransactionPursharedAsync(TransactionPurshared value, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogBrand> UpdateCatalogBrandAsync(CatalogBrand value, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<CoinType> UpdateCoinTypeAsync(CoinType value, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
