using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfApp3.BusinessLogic;
using WpfApp3.Commands;
using WpfApp3.DataManagement;

namespace WpfApp3 {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            //NOTE: In App.xaml, I removed StartupUri.

            //This is mandatory, unless this assignment the application
            //will not terminate if the main window is closed.
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;

            IServiceProvider provider = ConfigureServices(new ServiceCollection()).BuildServiceProvider();

            MainWindow = provider.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services) {
            return services
                //Business logic layer
                .AddSingleton<IVirtualMoneyService, VirtualMoneyService>()
                .AddSingleton<IBackgroundService, ScheduledMoneyAddingService>(
                    provider => {
                        return new ScheduledMoneyAddingService(
                            virtualMoneyService: provider.GetRequiredService<IVirtualMoneyService>(),
                            amount: 150,
                            interval: TimeSpan.FromSeconds(5)
                        );
                    }
                )

                //Data management layer
                .AddSingleton<IVirtualMoneyDataManager, InMemoryVirtualMoneyDataManager>()

                //Presentation layer

                //NOTE: this is how you register a single implementation for multiple interfaces
                .AddSingleton<MoneyAddedNotificationToEventAdapter>()
                .AddSingleton<IMoneyAddedNotificationService>(provider => provider.GetRequiredService<MoneyAddedNotificationToEventAdapter>())
                .AddSingleton<IEventNotification<MoneyAddedNotificationToEventAdapter.MoneyAddedEventArgs>>(provider => provider.GetRequiredService<MoneyAddedNotificationToEventAdapter>())

                .AddSingleton<IStartAddingMoneyCommand, StartAddingMoneyCommand>()

                //NOTE: this is how you instantiate using a specific ctor
                .AddSingleton<MainWindowViewModel>(provider => 
                    new MainWindowViewModel(
                        provider.GetRequiredService<IStartAddingMoneyCommand>(),
                        provider.GetRequiredService<IEventNotification<MoneyAddedNotificationToEventAdapter.MoneyAddedEventArgs>>()
                    )
                )
                .AddSingleton<MainWindow>();
        }
    }
}
