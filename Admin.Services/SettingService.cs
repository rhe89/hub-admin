using System;
using System.Linq;
using System.Threading.Tasks;
using Admin.Integration;
using Admin.ViewModels;
using Hub.Storage.Dto;
using Hub.Web.ViewModels;

namespace Admin.Services
{
    public class SettingService<TApiConnector> : ISettingService<TApiConnector>
        where TApiConnector : IAdminApiConnector
    {
        private readonly TApiConnector _apiConnector;

        public SettingService(TApiConnector apiConnector)
        {
            _apiConnector = apiConnector;
        }

        public async Task UpdateSetting(string key, object value)
        {
            var settingDto = new SettingDto
            {
                Key = key,
                Value = value.ToString()
            };
            
            await _apiConnector.UpdateSetting(settingDto);
        }
        
        public async Task<SettingsViewModel> GetSettings()
        {
            var response = await _apiConnector.GetSettings();

            if (!response.Success)
                return ViewModelMappings.GetErrorViewModel<SettingsViewModel, SettingDto[]>(response);

            return new SettingsViewModel
            {
                Success = true,
                Settings = response.Data.Select(x => new SettingViewModel
                {
                    Key = x.Key,
                    Value = GetSettingValue(x.Value)
                }).ToList()
            };
        }

        private static object GetSettingValue(string value)
        {
            var isNumber = int.TryParse(value, out var number);

            if (isNumber)
                return number;
            
            var isDateTime = DateTime.TryParse(value, out var date);

            if (isDateTime)
                return date;

            return value;
        }
    }
}