using System.Linq;
using System.Threading.Tasks;
using Admin.Integration;
using Admin.ViewModels;
using Hub.Storage.Dto;
using Hub.Web.ViewModels;

namespace Admin.Services
{
    public class WorkerLogService<TApiConnector> : IWorkerLogService<TApiConnector>
        where TApiConnector : IAdminApiConnector
    {
        private readonly TApiConnector _apiConnector;

        public WorkerLogService(TApiConnector apiConnector)
        {
            _apiConnector = apiConnector;
        }
        
        public async Task<WorkerLogsViewModel> GetWorkerLogs(int ageInDays)
        {
            var workerLogsResponse = await _apiConnector.GetWorkerLogs(ageInDays);
            
            if (!workerLogsResponse.Success)
            {
                return ViewModelMappings.GetErrorViewModel<WorkerLogsViewModel, WorkerLogDto[]>(workerLogsResponse);
            }

            return new WorkerLogsViewModel
            {
                Success = true,
                WorkerLogs = workerLogsResponse.Data
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new WorkerLogViewModel
                    {
                        Name = x.Name,
                        Success = x.Success,
                        ErrorMessage = x.ErrorMessage,
                        CreatedDate = x.CreatedDate 
                    }).ToList()
            };
        }
    }
}