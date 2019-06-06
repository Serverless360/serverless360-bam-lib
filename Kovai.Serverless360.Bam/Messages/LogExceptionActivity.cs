#region Using Directives
using System; 
#endregion

namespace Kovai.Serverless360.Bam
{
	public class LogExceptionActivityRequest
	{
		public Guid StageActivityId { get; set; }
		public string ExceptionMessage { get; set; }
		public string ExceptionCode { get; set; }
		public string BusinessProcess { get; set; }
		public bool IsValid()
		{
			return true;
		}
	}
}
