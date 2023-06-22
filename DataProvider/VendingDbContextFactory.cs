using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataProvider
{
    public class VendingDbContextFactory : IDbContextFactory<VendingDbContext>
    {
        public IConfiguration? Configuration { get; }

        private string? connectionString;

        public VendingDbContextFactory(IConfiguration configuration)
        {
            this.Configuration = configuration;

            connectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public VendingDbContext CreateDbContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<VendingDbContext>();

            optionBuilder.UseSqlServer(connectionString);

            return new VendingDbContext(optionBuilder.Options);
        }
    }
}
