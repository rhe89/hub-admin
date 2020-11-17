using System.Collections.Generic;
using Hub.Web.BlazorServer.ViewModels;

namespace Admin.BlazorApp.ViewModel
{
    public class SettingsViewModel : ApiResponseViewModel
    {
        public IList<SettingViewModel> Settings { get; set; }
    }
}