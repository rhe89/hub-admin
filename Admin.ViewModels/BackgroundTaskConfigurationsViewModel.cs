using System.Collections.Generic;
using Hub.Web.ViewModels;

namespace Admin.ViewModels
{
    public class BackgroundTaskConfigurationsViewModel : ApiResponseViewModel
    {
        public IList<BackgroundTaskConfigurationViewModel> BackgroundTaskConfigurations { get; set; }
    }
}