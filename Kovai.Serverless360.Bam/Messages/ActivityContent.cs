using System.Runtime.Serialization;

namespace Kovai.Serverless360.Bam
{
	[DataContract]
	internal class ActivityContent
	{
		[DataMember]
		public string MessageBody { get; set; }
		[DataMember]
		public string MessageHeader { get; set; }
	}
}
