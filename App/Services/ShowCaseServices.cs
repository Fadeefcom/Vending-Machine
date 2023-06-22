using ApplicationCore;
using AutoMapper;
using DataProvider.Entities;
using DataProvider.Handler;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class ShowCaseServices : IShowCaseServices
    {
        private readonly IDataProvider _dataProvider;

        private readonly IMapper _mapper;

        public ShowCaseServices(IDataProvider dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }

        public async Task<bool> AddCoinAsync(ApplicationInstace instace, CoinTypeViewModel coinType, CancellationToken token)
        {
            var val = await _dataProvider.GetCoinTypeAsync(coinType.Id, token);

            instace.AddCoin(val);

            return true;
        }

        public async Task<bool> AddToCardAsync(ApplicationInstace instace, int catalogBrandId, CancellationToken token)
        {
            var result = instace.AddSelectedCatalogBrand(await _dataProvider.GetCatalogItemAsync(catalogBrandId, token));

            return result;
        }

        public async Task<List<CatalogItemViewModel>> GetCatalogItemViewModels(CancellationToken token)
        {
            var temp = await _dataProvider.GetCatalogItemsAsync(token);

            return _mapper.Map<List<CatalogItemViewModel>>(temp);
        }

        public async Task<List<CoinTypeViewModel>> GetCoinTypeViewModels(CancellationToken token)
        {
            var temp = await _dataProvider.GetCointTypeAsync(token);

            return _mapper.Map<List<CoinTypeViewModel>>(temp);
        }

        public async Task<List<CoinTypeViewModel>> PayAsync(ApplicationInstace instace, CancellationToken token)
        {
            var coinsreturned = await instace.BuySelectedCatalogBrands();

            return _mapper.Map<List<CoinTypeViewModel>>(coinsreturned.Select(_ => _.CoinType));
        }
    }
}
