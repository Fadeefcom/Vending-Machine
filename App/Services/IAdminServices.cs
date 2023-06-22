using VendingMachine.Models;

namespace VendingMachine.Services
{
    public interface IAdminServices
    {
        event Action RefreshRequested;
        void CallRequestRefresh();

        public Task<bool> AddItemToViewModel(AdminItemViewModel viewModel, CancellationToken token);

        public Task<bool> DeleteItemFromViewModel(AdminItemViewModel viewModel, CancellationToken token);

        public Task<AdminItemViewModel> EditItemFromViewModel(AdminItemViewModel viewModel, CancellationToken token);

        public Task<AdminItemViewModel> Copy(AdminItemViewModel viewModel, CancellationToken token);

        public Task<IEnumerable<AdminItemViewModel>> GetAll(CancellationToken token);

        public Task<bool> AddItemToViewModel(CoinTypeViewModel viewModel, CancellationToken token);

        public Task<bool> DeleteItemFromViewModel(CoinTypeViewModel viewModel, CancellationToken token);

        public Task<CoinTypeViewModel> EditItemFromViewModel(CoinTypeViewModel viewModel, CancellationToken token);

        public Task<CoinTypeViewModel> Copy(CoinTypeViewModel viewModel, CancellationToken token);

        public Task<IEnumerable<CoinTypeViewModel>> GetAllCoins(CancellationToken token);
    }
}
