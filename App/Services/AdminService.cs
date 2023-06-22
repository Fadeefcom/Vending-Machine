using AutoMapper;
using DataProvider.Entities;
using DataProvider.Handler;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class AdminService : IAdminServices
    {
        private readonly IDataProvider _dataProvider;

        private readonly IMapper _mapper;

        public AdminService(IDataProvider dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }

        public event Action RefreshRequested;

        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }

        public async Task<bool> AddItemToViewModel(AdminItemViewModel viewModel, CancellationToken token)
        {
            try
            {
                var temp = _mapper.Map<CatalogBrand>(viewModel);

                await _dataProvider.PutCatalogBrandAsync(temp, token);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<AdminItemViewModel> Copy(AdminItemViewModel viewModel, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
                return Task.FromResult(_mapper.Map<AdminItemViewModel>(viewModel));
            else
                return Task.FromResult(new AdminItemViewModel());
        }

        public async Task<bool> DeleteItemFromViewModel(AdminItemViewModel viewModel, CancellationToken token)
        {
            var temp = _mapper.Map<CatalogBrand>(viewModel);

            return await _dataProvider.DeleteCatalogBrandAsync(temp, token);
        }

        public async Task<AdminItemViewModel> EditItemFromViewModel(AdminItemViewModel viewModel, CancellationToken token)
        {
            viewModel.Loading = true;

            var temp = _mapper.Map<CatalogBrand>(viewModel);

            var result = await _dataProvider.UpdateCatalogBrandAsync(temp, token);

            return _mapper.Map<AdminItemViewModel>(result);
        }

        public async Task<IEnumerable<AdminItemViewModel>> GetAll(CancellationToken token)
        {
            var temp = await _dataProvider.GetCatalogBrandsAsync(token);

            return _mapper.Map<AdminItemViewModel[]>(temp);
        }

        public async Task<bool> AddItemToViewModel(CoinTypeViewModel viewModel, CancellationToken token)
        {
            try
            {
                var temp = _mapper.Map<CoinType>(viewModel);

                await _dataProvider.PutCoinTypeAsync(temp, token);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemFromViewModel(CoinTypeViewModel viewModel, CancellationToken token)
        {
            var temp = _mapper.Map<CoinType>(viewModel);

            return await _dataProvider.DeleteCoinTypeAsync(temp, token);
        }

        public async Task<CoinTypeViewModel> EditItemFromViewModel(CoinTypeViewModel viewModel, CancellationToken token)
        {
            var temp = _mapper.Map<CoinType>(viewModel);

            var result = await _dataProvider.UpdateCoinTypeAsync(temp, token);

            return _mapper.Map<CoinTypeViewModel>(result);
        }

        public Task<CoinTypeViewModel> Copy(CoinTypeViewModel viewModel, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
                return Task.FromResult(_mapper.Map<CoinTypeViewModel>(viewModel));
            else
                return Task.FromResult(new CoinTypeViewModel());
        }

        public async Task<IEnumerable<CoinTypeViewModel>> GetAllCoins(CancellationToken token)
        {
            var temp = await _dataProvider.GetCointTypeAsync(token);

            return _mapper.Map<CoinTypeViewModel[]>(temp);
        }
    }
}
