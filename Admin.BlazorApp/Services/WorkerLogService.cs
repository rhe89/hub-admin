using System.Linq;
using System.Threading.Tasks;
using Admin.BlazorApp.ViewModel;
using Admin.Integration;
using Hub.Storage.Core.Dto;
using Hub.Web.BlazorServer.ViewModels;

namespace Admin.BlazorApp.Services
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