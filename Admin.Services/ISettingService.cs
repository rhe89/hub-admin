using System.Threading.Tasks;
using Admin.ViewModels;

namespace Admin.Services
{
    public interface ISettingService<TApiConnector>
    {
        Task UpdateSetting(string key, object value);
        Task<SettingsViewModel> GetSettings();
    }
}