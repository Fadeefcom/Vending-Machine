using Microsoft.AspNetCore.Components;
using VendingMachine.Models;

namespace VendingMachine.Pages
{
    partial class AdminPageCoins
    {
        [Parameter]
        public string SecretKey { get; set; }

        private IEnumerable<CoinTypeViewModel> adminItemViewModels = Enumerable.Empty<CoinTypeViewModel>();

        private CoinTypeViewModel model = new CoinTypeViewModel();

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private CancellationToken token;

        protected override async Task OnParametersSetAsync()
        {
            token = cancellationTokenSource.Token;

            adminItemViewModels = await AdminService.GetAllCoins(token);

            AdminService.RefreshRequested += RefreshMe;
        }

        private async void RefreshMe()
        {
            adminItemViewModels = await AdminService.GetAllCoins(token);
            StateHasChanged();
        }

        private async Task Submit()
        {
            await AdminService.AddItemToViewModel(model, token);

            adminItemViewModels = await AdminService.GetAllCoins(token);

            await InvokeAsync(() => StateHasChanged());
        }

        private void Clear()
        {
            model = new CoinTypeViewModel();
            StateHasChanged();
        }
    }
}
