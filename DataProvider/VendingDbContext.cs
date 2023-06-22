using DataProvider.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataProvider
{
    public class VendingDbContext : DbContext
    {
        public VendingDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<CatalogBrand> CatalogBrands { get; set; }

        public DbSet<CatalogItem> CatalogItems { get; set; }

        public DbSet<CoinType> CoinTypes { get; set; }

        public DbSet<ErrorDetail> ErrorDetails { get; set; }

        public DbSet<TransactionPurshared> TransactionPurshared { get; set; }

        public DbSet<CoinRecieved> CoinRecieveds { get; set; }

        public DbSet<CoinReturned> CoinReturneds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var catalogBrand = modelBuilder.Entity<CatalogBrand>();
            catalogBrand.Property(_ => _.Id).ValueGeneratedOnAdd();
            catalogBrand.HasIndex(_ => _.Name);
            catalogBrand.HasKey(_ => _.Id);

            var catalogItems = modelBuilder.Entity<CatalogItem>();
            catalogItems
                .HasKey(_ => _.Id);
            catalogItems
                .HasOne(_ => _.CatalogBrand)
                .WithMany(_ => _.CatalogItems)
                .HasForeignKey(_ => _.CatalogBrandId);

            var cointType = modelBuilder.Entity<CoinType>();
            cointType.HasKey(_ => _.Id);
            cointType.HasIndex(_ => _.Name);

            var errorDetail = modelBuilder.Entity<ErrorDetail>();
            errorDetail.HasKey(_ => _.Id);

            var transactionPurshared = modelBuilder.Entity<TransactionPurshared>();
            transactionPurshared.Property(_ => _.Id).ValueGeneratedOnAdd();
            transactionPurshared.HasKey(_ => _.Id);
            transactionPurshared.HasIndex(_ => _.Created);
            transactionPurshared.HasMany<CatalogItem>(_ => _.CatalogItems).WithOne(_ => _.TransactionPurshared).HasForeignKey(_ => _.Transaction);

            var coinReciev = modelBuilder.Entity<CoinRecieved>();
            coinReciev.HasKey(_ => _.Id);
            coinReciev.HasOne(_ => _.TransactionPurshared).WithMany(_ => _.CoinsRecieved).HasForeignKey(_ => _.TransactionId);
            coinReciev.HasOne(_ => _.CoinType).WithMany(_ => _.CoinsRecieved).HasForeignKey(_ => _.CoinId);

            var coinReturned = modelBuilder.Entity<CoinReturned>();
            coinReturned.HasKey(_ => _.Id);
            coinReturned.HasOne(_ => _.TransactionPurshared).WithMany(_ => _.CoinsReturned).HasForeignKey(_ => _.TransactionId);
            coinReturned.HasOne(_ => _.CoinType).WithMany(_ => _.CoinsReturned).HasForeignKey(_ => _.CoinId);
        }


    }
}