using ApplicationCore;
using DataProvider.Entities;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public interface IShowCaseServices  
    {
        Task<List<CatalogItemViewModel>> GetCatalogItemViewModels(CancellationToken token);

        Task<bool> AddToCardAsync(ApplicationInstace instace, int catalogBrandId, CancellationToken token);

        Task<List<CoinTypeViewModel>> GetCoinTypeViewModels(CancellationToken token);

        Task<bool> AddCoinAsync(ApplicationInstace instace, CoinTypeViewModel coinType, CancellationToken token);

        Task<List<CoinTypeViewModel>> PayAsync(ApplicationInstace instace, CancellationToken token);
    }
}
