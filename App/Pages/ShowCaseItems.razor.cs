using ApplicationCore;
using DataProvider.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Runtime.CompilerServices;
using System.Text;
using VendingMachine.Models;

namespace VendingMachine.Pages
{
    partial class ShowCaseItems
    {
        [Parameter]
        public CancellationToken token { get; set; }

        private List<CatalogItemViewModel> Items { get; set; } = new List<CatalogItemViewModel>();

        private List<CoinTypeViewModel> Coins { get; set; } = new List<CoinTypeViewModel>();

        private CoinTypeViewModel selectedValue { get; set; } = new CoinTypeViewModel();

        private List<CoinTypeViewModel> returned { get; set;} = new List<CoinTypeViewModel>();

        private string _selectedValue;

        private int Counter = 0;

        private bool DisabledAddButton = false;

        protected override async Task OnParametersSetAsync()
        {
            Items = await ShowCaseService.GetCatalogItemViewModels(token);
            Coins = await ShowCaseService.GetCoinTypeViewModels(token);
            applicationInstanse.ConfugureInstane(token);
        }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        private CancellationTokenSource token1 = new CancellationTokenSource();

        public async Task AddToCardAsync(CatalogItemViewModel viewModel)
        {
            token1.Cancel();
            token1.Dispose();
            token1 = new CancellationTokenSource();

            viewModel.Loading = true;
            var result = await ShowCaseService.AddToCardAsync(applicationInstanse, viewModel.Id, token);
            if (result)
            {
                viewModel.Message = "Item added";
                viewModel.Disabled = true;
            }
            else
            {
                viewModel.Disabled = false;
                viewModel.Message = "Item was not added";
            }
            _ = OnClose(viewModel, token1.Token);
            viewModel.Loading = false;
        }

        public async Task AddCoin()
        {
            DisabledAddButton = true;
            await ShowCaseService.AddCoinAsync(applicationInstanse, selectedValue, token);
            DisabledAddButton = false;
        }

        private CancellationTokenSource token2 = new CancellationTokenSource();
        public async Task Pay()
        {
            DisabledAddButton = true;

            token2.Cancel();
            token2.Dispose();
            token2 = new CancellationTokenSource();
            
            returned = await ShowCaseService.PayAsync(applicationInstanse, token);
            DisabledAddButton = false;
        }

        private void OnSelectedItemChangedHandler(CoinTypeViewModel value)
        {
            Console.WriteLine($"selected: ${value?.Name}");

            selectedValue = value;
        }

        private async Task OnClose(CatalogItemViewModel viewModel, CancellationToken token)
        {
            try
            {
                await Task.Delay(1000, token);
                viewModel.Message = string.Empty;
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex) { }
        }

        private double Balance
        {
            get
            {
                return applicationInstanse.Balance;
            }
            set
            {

            }
        }

        private string Returned
        {
            get
            {
                if (returned.Count() > 0)
                {
                    StringBuilder result = new StringBuilder();
                    foreach (var item in returned.GroupBy(_ => _.Name))
                    {
                        result.Append("Coin - ");
                        result.Append(item.Key);
                        result.Append(" x ");
                        result.Append(item.Count());
                        result.Append(" times | ");
                    }

                    return result.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {

            }
        }

    }


}
