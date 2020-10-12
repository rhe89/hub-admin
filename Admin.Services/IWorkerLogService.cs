using System.Threading.Tasks;
using Admin.ViewModels;

namespace Admin.Services
{
    public interface IWorkerLogService<TApiConnector>
    {
        Task<WorkerLogsViewModel> GetWorkerLogs(int ageInDays);
    }
}