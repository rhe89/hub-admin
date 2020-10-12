using System.Collections.Generic;
using System.Linq;
using Hub.Web.ViewModels;

namespace Admin.ViewModels
{
    public class WorkerLogsViewModel : ApiResponseViewModel
    {
        public List<WorkerLogViewModel> WorkerLogs { get; set; }

        public void AddWorkerLogs(IEnumerable<WorkerLogViewModel> workerLogViewModels)
        {
            WorkerLogs ??= new List<WorkerLogViewModel>();
            
            WorkerLogs.AddRange(workerLogViewModels);

            WorkerLogs = WorkerLogs.OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}