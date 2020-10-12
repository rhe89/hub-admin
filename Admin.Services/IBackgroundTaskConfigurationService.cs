using System.Threading.Tasks;
using Admin.ViewModels;
using Hub.Storage.Dto;

namespace Admin.Services
{
    public interface IBackgroundTaskConfigurationService<TApiClient>
    {
        Task UpdateRunIntervalType(string name, RunIntervalType runIntervalType);
        Task<BackgroundTaskConfigurationsViewModel> GetBackgroundTaskConfigurations();
    }
}