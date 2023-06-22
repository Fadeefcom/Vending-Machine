using AntDesign;
using DataProvider.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using VendingMachine.Models;

namespace VendingMachine.Pages
{
    partial class AdminPage
    {
        [Parameter]
        public string SecretKey { get; set; }

        private IEnumerable<AdminItemViewModel> adminItemViewModels = Enumerable.Empty<AdminItemViewModel>();

        private AdminItemViewModel model = new AdminItemViewModel();

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private CancellationToken token;

        protected override async Task OnParametersSetAsync()
        {
            token = cancellationTokenSource.Token;

            adminItemViewModels = await AdminService.GetAll(token);

            AdminService.RefreshRequested += RefreshMe;
        }

        private async void RefreshMe()
        {
            adminItemViewModels = await AdminService.GetAll(token);
            StateHasChanged();
        }

        private void OnFinish(EditContext editContext)
        {
            Console.WriteLine($"Success:{JsonSerializer.Serialize(model)}");
        }

        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(model)}");
        }

        private string Format(double value)
        {
            return "$ " + value.ToString("n0");
        }

        private async Task Submit()
        {
            await AdminService.AddItemToViewModel(model, token);

            adminItemViewModels = await AdminService.GetAll(token);            

            await InvokeAsync(() => StateHasChanged());
        }

        private void Clear()
        {
            model = new AdminItemViewModel();
            StateHasChanged();
        }    
    }
}
