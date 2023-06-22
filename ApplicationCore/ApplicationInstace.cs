using DataProvider.Handler;
using DataProvider.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApplicationCore
{
    public class ApplicationInstace
    {
        public double Balance { get; private set; } = 0.0;

        public List<CoinType> Coins { get; private set; } = new ();

        public List<CatalogItem> SelectedCatalogItems { get; private set; } = new ();

        private readonly IDataProvider _dataProvider;

        private readonly IServiceScopeFactory _scopefactory;

        private readonly ILoggerFactory _loggerFactory;

        private CancellationToken _token;

        public ApplicationInstace(AppBaseArguments baseArguments)
        {
            _dataProvider = baseArguments.dataProvider;
            _scopefactory = baseArguments.scopefactory;
            _loggerFactory = baseArguments.loggerFactory;
        }

        public void ConfugureInstane(CancellationToken token)
        {
            _token = token;
        }

        public void AddCoin(CoinType coin)
        {
            if (!coin.Disabled)
            {
                Coins.Add(coin);
                Balance += coin.Value;
            }
        }

        public bool AddSelectedCatalogBrand(CatalogItem value)
        {
            if (SelectedCatalogItems.Select(_ => _.CatalogBrand.Cost).Sum() + value.CatalogBrand.Cost <= Balance && value.IsDeleted == false)
            {
                SelectedCatalogItems.Add(value);
                return true;
            }
            else
                return false;
        }

        public async Task<List<CoinReturned>> BuySelectedCatalogBrands()
        {
            if(SelectedCatalogItems.Select(_ => _.CatalogBrand.Cost).Sum() <= Balance)
            {
                Balance -= SelectedCatalogItems.Select(_ => _.CatalogBrand.Cost).Sum();

                List<CoinReturned> result = await CalculateChange(Balance);
                List<CoinRecieved> recieveds = new List<CoinRecieved>();

                foreach(var c in Coins)
                {
                    recieveds.Add(new CoinRecieved() { CoinId = c.Id, CoinType = c });
                }

                await _dataProvider.PutTransactionPursharedAsync(new TransactionPurshared()
                {
                    CatalogItems = SelectedCatalogItems,
                    AmountPurshared = SelectedCatalogItems.Count(),
                    CoinsRecieved = recieveds,
                    Withdrawal = SelectedCatalogItems.Select(_ => _.CatalogBrand.Cost).Sum(),
                    CoinsReturned = result
                }, _token);

                SelectedCatalogItems = new List<CatalogItem>();
                Coins = new List<CoinType>();
                Balance = 0;

                return result;
            }
            return new ();
        }

        public void BuyCatalogBrand(CatalogBrand value)
        {

        }
            
        private async Task<List<CoinReturned>> CalculateChange(double balance)
        {
            var coins = await _dataProvider.GetCointTypeAsync(_token);

            List<CoinReturned> result = new();

            foreach(var coin in coins.OrderByDescending(_ => _.Value))
            {
                if(balance /  coin.Value >= 1.0)
                {
                    var temp = Math.Floor(balance / coin.Value);
                    balance -= coin.Value * temp;

                    for(int i = 0; i < temp; i++)
                        result.Add(new CoinReturned() { CoinId = coin.Id, CoinType = coin});
                }
            }
            return result;
        }
    }
}