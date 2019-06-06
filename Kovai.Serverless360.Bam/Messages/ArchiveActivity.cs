#region Using Directives
using System; 
#endregion

namespace Kovai.Serverless360.Bam
{
	public class ArchiveActivityRequest
	{
		public string BusinessProcess { get; set; }
		public string BusinessTransaction { get; set; }
		public string CurrentStage { get; set; }
		public Guid StageActivityId { get; set; }
		public string MessageBody { get; set; }
		public string MessageHeader { get; set; }
		public bool IsValid()
		{
			return true;
		}
	}
}