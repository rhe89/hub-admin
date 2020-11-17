using System.Net.Http;
using System.Threading.Tasks;
using Hub.Storage.Core.Dto;
using Hub.Web.Http;
using Microsoft.Extensions.Logging;

namespace Admin.Integration
{
    public abstract class AdminApiConnector : HttpClientService, IAdminApiConnector
    {
        private const string WorkerLogsPath = "/api/worker/logs";
        private const string SettingsPath = "/api/setting/settings";
        private const string BackgroundTaskConfigurationsPath = "/api/backgroundtaskconfiguration/backgroundtaskconfigurations";
        private const string UpdateBackgroundTaskConfigurationRunIntervalTypePath = "/api/backgroundtaskconfiguration/updaterunintervaltype";
        private const string UpdateSettingsPath = "/api/setting/update";
        
        protected AdminApiConnector(HttpClient httpClient, ILogger<AdminApiConnector> logger, string friendlyApiName) : base(httpClient, logger, friendlyApiName)
        {
        }
        
        public async Task<Response<WorkerLogDto[]>> GetWorkerLogs(int ageInDays)
        {
            return await Get<WorkerLogDto[]>(WorkerLogsPath, $"days={ageInDays}");
        }
        
        public async Task<Response<SettingDto[]>> GetSettings()
        {
            return await Get<SettingDto[]>(SettingsPath);
        }
        
        public async Task<Response<string>> UpdateSetting(SettingDto settingDto)
        {
            return await Post(UpdateSettingsPath, settingDto);
        }

        public async Task<Response<BackgroundTaskConfigurationDto[]>> GetBackgroundTaskConfigurations()
        {
            return await Get<BackgroundTaskConfigurationDto[]>(BackgroundTaskConfigurationsPath);
        }
        
        public async Task<Response<string>> UpdateBackgroundTaskConfigurationRunIntervalType(BackgroundTaskConfigurationDto backgroundTaskConfigurationDto)
        {
            return await Post(UpdateBackgroundTaskConfigurationRunIntervalTypePath, backgroundTaskConfigurationDto);
        }
    }
}