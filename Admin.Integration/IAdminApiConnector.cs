using System.Threading.Tasks;
using Hub.Storage.Dto;
using Hub.Web.Http;

namespace Admin.Integration
{
    public interface IAdminApiConnector
    {
        Task<Response<WorkerLogDto[]>> GetWorkerLogs(int ageInDays);
        Task<Response<SettingDto[]>> GetSettings();
        Task<Response<string>> UpdateSetting(SettingDto settingDto);
        Task<Response<BackgroundTaskConfigurationDto[]>> GetBackgroundTaskConfigurations();

        Task<Response<string>> UpdateBackgroundTaskConfigurationRunIntervalType(
            BackgroundTaskConfigurationDto backgroundTaskConfigurationDto);

    }
}