using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using STB_desktop.Services;

namespace STB_desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();


            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

        }
        private void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(sp => new HttpClient               
            {
                BaseAddress = new Uri("https://stb-backend-api-ckgpfhcdhsbuf6fw.francecentral-01.azurewebsites.net/api/")
            });
            // register application services here
            services.AddSingleton<AssetApiService>();
            services.AddSingleton<AuthApiService>();
            services.AddSingleton<BookingApiService>();
            services.AddSingleton<RoomApiService>();
            services.AddSingleton<UserApiService>();

            // ViewModels
            services.AddSingleton<ViewModel.MainViewModel>();
            services.AddSingleton<ViewModel.RoomsViewModel>();
            services.AddSingleton<ViewModel.AssetViewModel>();
            //services.AddSingleton<ViewModel.BookingsViewModel>();
            //services.AddSingleton<ViewModel.UsersViewModel>();

            services.AddSingleton<MainWindow>(sp =>
            {
                // construct MainWindow with MainViewModel injected into its constructor
                return new MainWindow(sp.GetRequiredService<ViewModel.MainViewModel>());
            });

            
        }
    }

}
