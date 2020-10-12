using System.Linq;
using System.Threading.Tasks;
using Admin.Integration;
using Admin.ViewModels;
using Hub.Storage.Dto;
using Hub.Web.ViewModels;

namespace Admin.Services
{
    public class BackgroundTaskConfigurationService<TApiConnector> : IBackgroundTaskConfigurationService<TApiConnector>
        where TApiConnector : IAdminApiConnector
    {
        private readonly TApiConnector _apiConnector;

        public BackgroundTaskConfigurationService(TApiConnector apiConnector)
        {
            _apiConnector = apiConnector;
        }

        public async Task UpdateRunIntervalType(string name, RunIntervalType runIntervalType)
        {
            var backgroundTaskConfigurationDto = new BackgroundTaskConfigurationDto
            {
                Name = name,
                RunIntervalType = runIntervalType
            };
            
            await _apiConnector.UpdateBackgroundTaskConfigurationRunIntervalType(backgroundTaskConfigurationDto);
        }
        
        public async Task<BackgroundTaskConfigurationsViewModel> GetBackgroundTaskConfigurations()
        {
            var response = await _apiConnector.GetBackgroundTaskConfigurations();

            if (!response.Success)
                return ViewModelMappings.GetErrorViewModel<BackgroundTaskConfigurationsViewModel, BackgroundTaskConfigurationDto[]>(response);

            return new BackgroundTaskConfigurationsViewModel
            {
                Success = true,
                BackgroundTaskConfigurations = response.Data.Select(x => new BackgroundTaskConfigurationViewModel
                {
                    Name = x.Name,
                    RunIntervalType = x.RunIntervalType,
                    LastRun = x.LastRun
                }).ToList()
            };
        }
    }
}