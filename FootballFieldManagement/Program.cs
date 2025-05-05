using System.Configuration;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Repositories;
using FootballFieldManagement.Repositories.Implementations;
using FootballFieldManagement.Repositories.Interfaces;
using FootballFieldManagement.Services.Implementations;
using FootballFieldManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FootballFieldManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var servicesCollection = new ServiceCollection();
            ConfigureServices(servicesCollection);

            // Build the service provider
            var serviceProvider = servicesCollection.BuildServiceProvider();

            // Resolve the main form
            var fieldController = serviceProvider.GetRequiredService<FieldController>();

            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            // Run the application with the main form
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FootballFieldManagementDB"].ConnectionString;

            services.AddDbContext<FootballFieldManagementDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register Repositpories
            services.AddScoped<IFieldRepository, FieldRepository>();

            // Register Services
            services.AddScoped<IFieldService, FieldService>();

            // Register Controllers
            services.AddScoped<FieldController>();

            // Register Forms
            services.AddTransient<FieldForm>();
            services.AddTransient<MainForm>();
        }
    }
}