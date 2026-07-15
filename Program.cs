using CSharpWinFormsPOCs._07_Caching.Repositories;
using CSharpWinFormsPOCs._07_Caching.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.Caching;
using System.Windows.Forms;

namespace CSharpWinFormsPOCs
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceCollection services = new ServiceCollection();

            // Singleton: One shared instance for the entire application.
            services.AddSingleton<IUserService, UserService>();

            // Transient: Creates a new form instance every time it is requested.
            services.AddTransient<DependencyIn>();

            // One cache instance for the entire application.
            services.AddSingleton<ObjectCache>(
                MemoryCache.Default);

            // Simulated database/API repository.
            services.AddSingleton<
                ICustomerRepository,
                SlowCustomerRepository>();

            // One caching service for the application.
            services.AddSingleton<CustomerCacheService>(
                serviceProvider =>
                    new CustomerCacheService(
                        serviceProvider
                            .GetRequiredService<ObjectCache>(),
                        serviceProvider
                            .GetRequiredService<ICustomerRepository>(),
                        TimeSpan.FromSeconds(15)));

            // Create a new form whenever requested.
            services.AddTransient<_07_Caching.cacheForm>();

            using (ServiceProvider serviceProvider =
                services.BuildServiceProvider())
            {
                //  Application.Run(serviceProvider.GetRequiredService<DependencyIn>());

                Application.Run(serviceProvider.GetRequiredService<_07_Caching.cacheForm>());
            }
        }
    }
}