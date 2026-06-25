using Microsoft.Extensions.DependencyInjection;
using System;
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

            // Create a new dependency injection (DI) service collection to register application services.
            var services = new ServiceCollection();

            // Singleton: One shared instance for the entire application.
            services.AddSingleton<IUserService, UserService>();

            // Transient: Creates a new form instance every time it is requested.
            services.AddTransient<DependencyIn>();

            // Creates the DI container used to resolve registered services.
            var serviceProvider = services.BuildServiceProvider();

            Application.Run(serviceProvider.GetRequiredService<DependencyIn>());
        }
    }
}