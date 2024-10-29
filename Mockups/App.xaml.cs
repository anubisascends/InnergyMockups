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
                services.AddHostedService<RootView>();

                services.AddSingleton<RootViewModel>();

                services.AddTransient<ToolView>();
                services.AddTransient<OptimizerExportDialogView>();

                services.AddTransient<ToolViewModel>();
                services.AddTransient<OptimizerExportDialogViewModel>();
            })
            .Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            Host.Start();
        }
    }

}
