using System.Threading.Tasks;

namespace Kovai.Serverless360.Bam
{
    public interface ITransactionService
    {
        Task<StartTransactionResponse> StartTransaction(StartTransactionRequest activityRequest);
        Task<bool> CheckPoint(CheckPointRequest activityRequest);
        Task<bool> CorrelationCheckPoint(CorrelationCheckPointRequest activityRequest);
    }
}
