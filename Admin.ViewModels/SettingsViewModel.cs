using System.Collections.Generic;
using Hub.Web.ViewModels;

namespace Admin.ViewModels
{
    public class SettingsViewModel : ApiResponseViewModel
    {
        public IList<SettingViewModel> Settings { get; set; }
    }
}