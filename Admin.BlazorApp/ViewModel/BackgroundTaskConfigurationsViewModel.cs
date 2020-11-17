using System.Collections.Generic;
using Hub.Web.BlazorServer.ViewModels;

namespace Admin.BlazorApp.ViewModel
{
    public class BackgroundTaskConfigurationsViewModel : ApiResponseViewModel
    {
        public IList<BackgroundTaskConfigurationViewModel> BackgroundTaskConfigurations { get; set; }
    }
}