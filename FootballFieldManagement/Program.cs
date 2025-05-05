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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            // Register Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingDetailService, BookingDetailService>();
            services.AddScoped<IPaymentService, PaymentService>();

            // Register Controllers
            services.AddScoped<UserController>();
            services.AddScoped<FieldController>();
            services.AddScoped<CustomerController>();
            services.AddScoped<BookingController>();
            services.AddScoped<BookingDetailController>();
            services.AddScoped<PaymentController>();

            // Register Forms
            services.AddTransient<MainForm>();
            services.AddTransient<FieldForm>();
            services.AddTransient<CustomerForm>();
        }
    }
}