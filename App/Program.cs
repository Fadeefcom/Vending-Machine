using ApplicationCore;
using DataProvider;
using DataProvider.Handler;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VendingMachine.Models;
using VendingMachine.Options;
using VendingMachine.Services;

namespace VendingMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
            .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json") // Grabs the appsettings JSON as the configuration source
            .Build();

            builder.Services.AddSingleton<IConfiguration>(provider => configuration);
            builder.Services.AddLogging();

            string connectString = configuration.GetConnectionString("DefaultConnection");
            SqlConnectionStringBuilder Sqlbuilder =
                new SqlConnectionStringBuilder(connectString);
            Console.WriteLine("Original: " + Sqlbuilder.ConnectionString);
            Console.WriteLine("AttachDBFileName={0}", Sqlbuilder.AttachDBFilename);

            Sqlbuilder.AttachDBFilename = @"D:\Repos\SQLSERVER\MSSQL15.SQLEXPRESS\MSSQL\DATA\Vending_DEV.mdf";

            Console.WriteLine("Modified: " + Sqlbuilder.ConnectionString);

            using (SqlConnection connection = new SqlConnection(Sqlbuilder.ConnectionString))
            {
                connection.Open();
                // Now use the open connection.
                Console.WriteLine("Database = " + connection.Database);
            }

            //builder.Services.AddDbContextFactory<VendingDbContext, VendingDbContextFactory>(lifetime: ServiceLifetime.Scoped);
            builder.Services.AddDbContext<VendingDbContext>();
            builder.Services.AddScoped<IDataProvider, DataProvider.Handler.DataProvider>();
            //builder.Services.AddScoped<AppBaseArguments>();

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddAntDesign();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddControllers();

            builder.Services.AddTransient<BaseArguments>(provider => new BaseArguments() { 
                loggerFactory = provider.GetRequiredService<ILoggerFactory>(),
                scopefactory = provider.GetRequiredService<IServiceScopeFactory>()
                });
            builder.Services.AddTransient<AppBaseArguments>(provider => new AppBaseArguments()
            {
                dataProvider = provider.GetRequiredService<IDataProvider>(),
                scopefactory = provider.GetRequiredService<IServiceScopeFactory>(),
                loggerFactory = provider.GetRequiredService<ILoggerFactory>()
            });

            builder.Services.AddTransient<ApplicationInstace>();
            builder.Services.AddScoped<IAdminServices, AdminService>();
            builder.Services.AddScoped<IShowCaseServices, ShowCaseServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Logger.LogInformation("App created...");

            app.Run();
        }

    }
}