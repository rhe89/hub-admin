using System.Threading.Tasks;
using Admin.BlazorApp.ViewModel;

namespace Admin.BlazorApp.Services
{
    public interface ISettingService<TApiConnector>
    {
        Task UpdateSetting(string key, object value);
        Task<SettingsViewModel> GetSettings();
    }
}