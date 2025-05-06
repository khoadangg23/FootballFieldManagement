using System.Configuration;
using FootballFieldManagement.Controllers;
using FootballFieldManagement.Repositories;
using FootballFieldManagement.Repositories.Implementations;
using FootballFieldManagement.Repositories.Interfaces;
using FootballFieldManagement.Services.Implementations;
using FootballFieldManagement.Services.Interfaces;
using FootballFieldManagement.Views;
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


            // 1. Resolve LoginForm t? ServiceProvider
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();

            // 2. Hi?n th? LoginForm d??i d?ng modal dialog
            // Application.Run() CH?A ch?y ? ?ây. ShowDialog() có vòng l?p thông ?i?p riêng.
            DialogResult result = loginForm.ShowDialog();

            // 3. Ki?m tra k?t qu? c?a Dialog (khi LoginForm ?óng l?i)
            if (result == DialogResult.OK)
            {
                // 4. N?u ??ng nh?p thành công (LoginForm ??t DialogResult = OK và ?óng):
                // Resolve MainForm t? ServiceProvider
                var mainForm = serviceProvider.GetRequiredService<MainForm>();

                // Ch?y ?ng d?ng chính v?i MainForm.
                // Vòng l?p thông ?i?p chính c?a ?ng d?ng b?t ??u t? ?ây.
                Application.Run(mainForm);
            }
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

            // Register Session Service
            services.AddSingleton<ISessionService, SessionService>();

            // Register Controllers
            services.AddScoped<UserController>();
            services.AddScoped<FieldController>();
            services.AddScoped<CustomerController>();
            services.AddScoped<BookingController>();
            services.AddScoped<BookingDetailController>();
            services.AddScoped<PaymentController>();

            // Register Forms
            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<BookingForm>();
            services.AddTransient<FieldForm>();
            services.AddTransient<CustomerForm>();
            services.AddTransient<UserForm>();
            services.AddTransient<AddBookingForm>();
            services.AddTransient<PasswordChangeForm>();
        }
    }
}