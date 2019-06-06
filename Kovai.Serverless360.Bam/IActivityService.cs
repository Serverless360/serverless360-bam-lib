#region Using Directives
using System.Threading.Tasks; 
#endregion

namespace Kovai.Serverless360.Bam
{
    public interface IActivityService
    {
	    Task<StartActivityResponse> StartActivity(StartActivityRequest activityRequest);
	    Task<bool> UpdateActivity(UpdateActivityRequest activityRequest);
	    Task<bool> ArchiveActivity(ArchiveActivityRequest activityRequest);
	    Task<bool> LogExceptionActivity(LogExceptionActivityRequest activityRequest);
    }
}
