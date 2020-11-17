using System.Threading.Tasks;
using Admin.BlazorApp.ViewModel;

namespace Admin.BlazorApp.Services
{
    public interface IWorkerLogService<TApiConnector>
    {
        Task<WorkerLogsViewModel> GetWorkerLogs(int ageInDays);
    }
}