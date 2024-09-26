using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mockups.ViewModels;
using Mockups.Views;
using System.Windows;

namespace Mockups
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static IHost Host { get; } = new HostBuilder()
            .ConfigureServices(services => {
                services.AddSingleton<RootView>();

                services.AddTransient<ToolView>();

                services.AddSingleton<RootViewModel>();

                services.AddTransient<ToolViewModel>();
            })
            .Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            var view = Host.Services.GetRequiredService<RootView>();

            view.Show();
        }
    }

}
