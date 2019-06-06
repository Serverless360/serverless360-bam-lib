#region Using Directives
using System; 
#endregion

namespace Kovai.Serverless360.Bam
{
	public class UpdateActivityRequest
	{
		public string BusinessProcess { get; set; }
		public string BusinessTransaction { get; set; }
		public string CurrentStage { get; set; }
		public string MessageBody { get; set; }
		public string MessageHeader { get; set; }
		public Guid MainActivityId { get; set; }
		public Guid StageActivityId { get; set; }
		public StageStatus Status { get; set; }
		public bool IsArchiveEnabled { get; set; }
		
		public bool IsValid()
		{
			return true;
		}
	}
}