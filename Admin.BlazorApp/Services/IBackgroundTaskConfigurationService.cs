using System.Threading.Tasks;
using Admin.BlazorApp.ViewModel;
using Hub.Storage.Core.Dto;

namespace Admin.BlazorApp.Services
{
    public interface IBackgroundTaskConfigurationService<TApiClient>
    {
        Task UpdateRunIntervalType(string name, RunIntervalType runIntervalType);
        Task<BackgroundTaskConfigurationsViewModel> GetBackgroundTaskConfigurations();
    }
}