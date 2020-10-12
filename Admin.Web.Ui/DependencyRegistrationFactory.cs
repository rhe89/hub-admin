using System;
using Admin.Integration;
using Admin.Services;
using Admin.Web.Ui.Services;
using Blazored.Modal;
using Hub.Web.DependencyRegistration;
using Hub.Web.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Web.Ui
{
    public class DependencyRegistrationFactory : WebDependencyRegistrationFactory
    {
        protected override void AddBlazor(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddRazorPages();
            serviceCollection.AddServerSideBlazor();
            serviceCollection.AddBlazoredModal();
            serviceCollection.AddTransient<BrowserService>();
        }

        protected override void AddHttpClients(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHubHttpClient<ISbankenApiConnector, SbankenApiConnector>(client =>
                client.BaseAddress = new Uri(configuration.GetValue<string>("SBANKEN_API_HOST")));
            
            serviceCollection.AddHubHttpClient<ICoinbaseApiConnector, CoinbaseApiConnector>(client =>
                client.BaseAddress = new Uri(configuration.GetValue<string>("COINBASE_API_HOST")));
            
            serviceCollection.AddHubHttpClient<ISpreadsheetApiConnector, SpreadsheetApiConnector>(client =>
                client.BaseAddress = new Uri(configuration.GetValue<string>("SPREADSHEET_API_HOST")));
        }

        protected override void AddServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<ISettingService<ISbankenApiConnector>, SettingService<ISbankenApiConnector>>();
            serviceCollection.AddTransient<IWorkerLogService<ISbankenApiConnector>, WorkerLogService<ISbankenApiConnector>>();
            serviceCollection.AddTransient<IBackgroundTaskConfigurationService<ISbankenApiConnector>, BackgroundTaskConfigurationService<ISbankenApiConnector>>();

            serviceCollection.AddTransient<ISettingService<ICoinbaseApiConnector>, SettingService<ICoinbaseApiConnector>>();
            serviceCollection.AddTransient<IWorkerLogService<ICoinbaseApiConnector>, WorkerLogService<ICoinbaseApiConnector>>();
            serviceCollection.AddTransient<IBackgroundTaskConfigurationService<ICoinbaseApiConnector>, BackgroundTaskConfigurationService<ICoinbaseApiConnector>>();
            
            serviceCollection.AddTransient<ISettingService<ISpreadsheetApiConnector>, SettingService<ISpreadsheetApiConnector>>();
            serviceCollection.AddTransient<IWorkerLogService<ISpreadsheetApiConnector>, WorkerLogService<ISpreadsheetApiConnector>>();
            serviceCollection.AddTransient<IBackgroundTaskConfigurationService<ISpreadsheetApiConnector>, BackgroundTaskConfigurationService<ISpreadsheetApiConnector>>();
        }
    }
}