using DataProvider;
using DataProvider.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DataProvider.Handler
{
    public class DataProvider : FailHandler, IDataProvider
    {
        private readonly IServiceScopeFactory _scopefactory;

        private readonly ILoggerFactory _loggerFactory;

        private readonly ILogger<DataProvider> _logger;

        public DataProvider(BaseArguments args) : base(args)
        {
            _scopefactory = args.scopefactory;
            _loggerFactory = args.loggerFactory;

            _logger = _loggerFactory.CreateLogger<DataProvider>();
        }

        public new async Task<IEnumerable<CatalogBrand>> GetCatalogBrandsAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using(var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var result = await _context.CatalogBrands.Include(_ => _.CatalogItems.Where(_ => _.IsDeleted == false)).AsNoTracking().ToListAsync(token).ConfigureAwait(false);

                    if (result.Any())
                    {
                        _logger.LogInformation("Database returned {0}:{1} in function {3}", result.Count(), typeof(CatalogBrand).Name, "GetCatalogBrandsAsync");
                        return result;
                    }
                    else
                        return await base.GetCatalogBrandsAsync(token);
                }
            }
            else
            {
                return Array.Empty<CatalogBrand>();
            }
        }

        public new async Task<CatalogBrand> UpdateCatalogBrandAsync(CatalogBrand value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var entity = await _context.CatalogBrands.Include(_ => _.CatalogItems).FirstOrDefaultAsync(_ => _.Name == value.Name);

                    if(entity == null)
                        return await base.UpdateCatalogBrandAsync(value, token);

                    entity.Cost = value.Cost;
                    entity.Volume = value.Volume;
                    entity.CatalogItems = entity.CatalogItems.Where(_ => _.IsDeleted == true).ToList();

                    int count = value.CatalogItems.Count();

                    for(int i = 0; i < count; i++)
                    {
                        var temp = new CatalogItem();
                        temp.CatalogBrandId = entity.Id;
                        temp.CatalogBrand = entity;
                        entity.CatalogItems.Add(temp);
                    }

                    var result = _context.CatalogBrands.Update(entity);

                    if (result.State == EntityState.Modified)
                    {
                        _logger.LogInformation("Database successfully added {0}, {1}", result.Entity.Id, typeof(CatalogBrand).Name);
                        await _context.SaveChangesAsync();
                        var temp = await _context.CatalogBrands.Where(_ => _.Name == value.Name).Include(_ => _.CatalogItems.Where(_ => _.IsDeleted == false)).AsNoTracking().FirstAsync();
                        return temp;
                    }
                    else
                        return await base.UpdateCatalogBrandAsync(value, token);
                }
            }
            return new CatalogBrand();
        }

        public new async Task<CatalogBrand> GetCatalogBrandsAsync(int id, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var result = await _context.CatalogBrands.Where(_ => _.Id == id).Include(_ => _.CatalogItems.Where(_ => _.IsDeleted == false)).AsNoTracking().FirstOrDefaultAsync(token).ConfigureAwait(false);

                    if (result != null)
                    {
                        _logger.LogInformation("Database returned {0}:{1} in function {3}", result.Id, typeof(CatalogBrand).Name, "GetCatalogBrandsAsync");
                        return result;
                    }
                    else
                        return await base.GetCatalogBrandsAsync(id, token);
                }
            }
            else
            {
                return new CatalogBrand();
            }
        }

        public new async Task<CatalogItem> GetCatalogItemAsync(int id, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var result = await _context.CatalogItems.Where(_ => _.Id == id).Include(_ => _.CatalogBrand).AsNoTracking().FirstOrDefaultAsync(token).ConfigureAwait(false);

                    if (result != null)
                    {
                        _logger.LogInformation("Database returned {0}:{1} in function {3}", result.Id, typeof(CoinType).Name, "GetCatalogItemAsync");
                        return result;
                    }
                    else
                        return await base.GetCatalogItemAsync(id, token);
                }
            }
            else
            {
                return new CatalogItem();
            }
        }

        public new async Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var result = await _context.CatalogItems.Where(_ => _.IsDeleted == false).Include(_ => _.CatalogBrand).AsNoTracking().ToListAsync(token).ConfigureAwait(false);

                    if (result.Any())
                    {
                        _logger.LogInformation("Database returned {0}:{1} in function {3}", result.Count(), typeof(CatalogItem).Name, "GetCatalogItemsAsync");
                        return result;
                    }
                    else
                        return await base.GetCatalogItemsAsync(token);
                }
            }
            else
            {
                return Array.Empty<CatalogItem>();
            }
        }

        public new async Task<IEnumerable<CoinType>> GetCointTypeAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var result = await _context.CoinTypes.AsNoTracking().ToListAsync(token).ConfigureAwait(false);

                    if (result.Any())
                    {
                        _logger.LogInformation("Database returned {0}:{1} in function {3}", result.Count(), typeof(CoinType).Name, "GetCointTypeAsync");
                        return result;
                    }
                    else
                        return await base.GetCointTypeAsync(token);
                }
            }
            else
            {
                return Array.Empty<CoinType>();
            }
        }

        public new async Task<CoinType> GetCoinTypeAsync(int id, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var result = await _context.CoinTypes.Where(_ => _.Id == id).AsNoTracking().FirstOrDefaultAsync(token).ConfigureAwait(false);

                    if (result != null)
                    {
                        _logger.LogInformation("Database returned {0}:{1} in function {3}", result.Id, typeof(CoinType).Name, "GetCoinTypeAsync");
                        return result;
                    }
                    else
                        return await base.GetCoinTypeAsync(id, token);
                }
            }
            else
            {
                return new CoinType();
            }
        }

        public new async Task<ErrorDetail> GetErrorDetailAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public new async Task<IEnumerable<ErrorDetail>> GetErrorDetailsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public new async Task<TransactionPurshared> GetTransactionPursharedAsync(int id, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var result = await _context.TransactionPurshared
                        .Where(_ => _.Id == id)
                        .Include(_ => _.CatalogItems)
                        .Include(_ => _.CoinsReturned)
                        .Include(_ => _.CoinsRecieved)
                        .AsNoTracking().FirstOrDefaultAsync(token).ConfigureAwait(false);

                    if (result != null)
                    {
                        _logger.LogInformation("Database returned {0}:{1} in function {3}", result.Id, typeof(TransactionPurshared).Name, "GetTransactionPursharedAsync");
                        return result;
                    }
                    else
                        return await base.GetTransactionPursharedAsync(id, token);
                }
            }
            else
            {
                return new TransactionPurshared() { 
                CatalogItems = new List<CatalogItem>(),
                CoinsRecieved = new List<CoinRecieved>(),
                CoinsReturned = new List<CoinReturned>()};
            }
        }

        public new async Task<IEnumerable<TransactionPurshared>> GetTransactionPursharedsAsync(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var result = await _context.TransactionPurshared
                        .Include(_ => _.CatalogItems)
                        .Include(_ => _.CoinsReturned)
                        .Include(_ => _.CoinsRecieved)
                        .AsNoTracking().ToListAsync(token).ConfigureAwait(false);

                    if (result != null)
                    {
                        _logger.LogInformation("Database returned {0}:{1} in function {3}", result.Count(), typeof(TransactionPurshared).Name, "GetTransactionPursharedAsync");
                        return result;
                    }
                    else
                        return await base.GetTransactionPursharedsAsync(token);
                }
            }
            else
            {
                return Enumerable.Empty<TransactionPurshared>();
            }
        }

        public new async Task<bool> PutCatalogBrandAsync(CatalogBrand value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    if(await _context.CatalogBrands.AnyAsync(_ => _.Name == value.Name) || value.Name == null || value.Name == string.Empty)
                        return await base.PutCatalogBrandAsync(value, token);

                    var count = value.CatalogItems.Count();

                    value.CatalogItems.Clear();

                    for (int i = 0; i <  count; i++)                    {
                        value.CatalogItems.Add(new CatalogItem()
                        {
                            CatalogBrand = value
                        });
                    }

                    var result = await _context.CatalogBrands.AddAsync(value);

                    if (result.State == EntityState.Added)
                    {
                        _logger.LogInformation("Database successfully added {0}, {1}", value.Id, typeof(CatalogBrand).Name);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                        return await base.PutCatalogBrandAsync(value, token);
                }
            }
            return false;
        }

        public new async Task<bool> DeleteCatalogBrandAsync(CatalogBrand value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var result = (await _context.CatalogBrands.FirstOrDefaultAsync(_ => _.Name == value.Name));

                    if (result != null)
                    {
                        var temp = _context.Remove(result);
                        _logger.LogInformation("Database successfully remove {0}, {1}, State: {3}", temp.Entity.Id, typeof(CatalogBrand).Name, temp.State.ToString());
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                        return await base.DeleteCatalogBrandAsync(value, token);
                }
            }
            return false;
        }

        public new async Task<bool> PutGatalogItemAsync(CatalogItem value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    if (await _context.CatalogBrands.AnyAsync(_ => _.Id == value.Id))
                        return await base.PutGatalogItemAsync(value, token);
                    
                    var result = await _context.CatalogItems.AddAsync(value);

                    if (result.State == EntityState.Added)
                    {
                        _logger.LogInformation("Database successfully added {0}, {1}", value.Id, typeof(CatalogItem).Name);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                        return await base.PutGatalogItemAsync(value, token);
                }
            }
            return false;
        }

        public new async Task<bool> PutErrorDetailAsync(ErrorDetail value, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public new async Task<bool> PutTransactionPursharedAsync(TransactionPurshared value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _scopefactory.CreateScope())
                    {
                        using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                        TransactionPurshared transaction = new TransactionPurshared()
                        {
                            CatalogItems = new List<CatalogItem>(),
                            CoinsRecieved = new List<CoinRecieved>(),
                            CoinsReturned = new List<CoinReturned>(),
                            AmountPurshared = value.AmountPurshared,
                            OverDraft = value.OverDraft,
                            Withdrawal = value.Withdrawal
                        };

                        var result = await _context.TransactionPurshared.AddAsync(transaction);

                        await _context.SaveChangesAsync();

                        foreach (var entity in value.CatalogItems)
                        {
                            var val = _context.CatalogItems.First(_ => _.Id == entity.Id);

                            val.TransactionPurshared = result.Entity;
                            val.Transaction = result.Entity.Id;
                            val.IsDeleted = true;
                        }

                        foreach (var entity in value.CoinsReturned)
                        {
                            entity.TransactionId = result.Entity.Id;
                            var cointype = _context.CoinTypes.First(_ => _.Id == entity.CoinId);
                            cointype.CoinsReturned.Add(entity);
                        }

                        foreach (var entity in value.CoinsRecieved)
                        {
                            entity.TransactionId = result.Entity.Id;
                            var cointype = _context.CoinTypes.First(_ => _.Id == entity.CoinId);
                            cointype.CoinsRecieved.Add(entity);
                        }

                        await _context.SaveChangesAsync();

                        _logger.LogInformation("Database successfully added {0}, {1}", value.Id, typeof(TransactionPurshared).Name);

                        return true;
                    }
                }
                catch(Exception e)
                {
                    return await base.PutTransactionPursharedAsync(value, token);
                }
            }
            return false;
        }

        public new async Task<bool> PutCoinTypeAsync(CoinType value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    if(value.Name == null || value.Name == "" || await _context.CoinTypes.AnyAsync(_ => _.Name == value.Name))
                        return await base.PutCoinTypeAsync(value, token);

                    var result = await _context.CoinTypes.AddAsync(value);

                    if (result.State == EntityState.Added)
                    {
                        _logger.LogInformation("Database successfully added {0}, {1}", value.Id, typeof(TransactionPurshared).Name);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                        return await base.PutCoinTypeAsync(value, token);
                }
            }
            return false;
        }

        public new async Task<bool> DeleteCoinTypeAsync(CoinType value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var entity = await _context.CoinTypes.AsNoTracking().FirstOrDefaultAsync(_ => _.Name == value.Name);

                    if (entity == null)
                        return await base.PutCoinTypeAsync(value, token);
                    
                    _context.Entry(entity).State = EntityState.Deleted;

                    _logger.LogInformation("Database successfully deleted {0}, {1}", value.Id, typeof(CoinType).Name);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public new async Task<CoinType> UpdateCoinTypeAsync(CoinType value, CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                using (var scope = _scopefactory.CreateScope())
                {
                    using var _context = scope.ServiceProvider.GetRequiredService<VendingDbContext>();

                    var entity = await _context.CoinTypes.FirstOrDefaultAsync(_ => _.Name == value.Name);

                    if (entity == null)
                        return await base.UpdateCoinTypeAsync(value, token);

                    entity.Value = value.Value;
                    entity.Disabled = value.Disabled;

                    var result = _context.CoinTypes.Update(entity);

                    if (result.State == EntityState.Modified)
                    {
                        _logger.LogInformation("Database successfully added {0}, {1}", value.Id, typeof(CoinType).Name);
                        var val = await _context.SaveChangesAsync();
                        return await _context.CoinTypes.AsNoTracking().FirstAsync(_ => _.Name == value.Name);
                    }
                    else
                        return await base.UpdateCoinTypeAsync(value, token);
                }
            }
            return new CoinType();
        }
    }
}
