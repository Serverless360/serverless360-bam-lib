#region Using Directives
using System;
using System.Runtime.Serialization;

#endregion

namespace Kovai.Serverless360.Bam
{
	[DataContract]
	public class LogExceptionActivityRequest
	{
		/// <summary>
		/// Gets or sets the stage activity identifier.
		/// </summary>
		/// <value>
		/// The stage activity identifier.
		/// </value>
		[DataMember]
		public Guid StageActivityId { get; set; }
		/// <summary>
		/// Gets or sets the exception message.
		/// </summary>
		/// <value>
		/// The exception message.
		/// </value>
		[DataMember]
		public string ExceptionMessage { get; set; }
		/// <summary>
		/// Gets or sets the exception code.
		/// </summary>
		/// <value>
		/// The exception code.
		/// </value>
		[DataMember]
		public string ExceptionCode { get; set; }
		/// <summary>
		/// Gets or sets the business process.
		/// </summary>
		/// <value>
		/// The business process.
		/// </value>
		[DataMember]
		public string BusinessProcess { get; set; }

		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <exception cref="InvalidStageActivityId"></exception>
		/// <exception cref="InvalidExceptionMessageCode"></exception>
		/// <exception cref="InvalidExceptionMessage"></exception>
		/// <exception cref="Kovai.Serverless360.Bam.InvalidBusinessProcessException"></exception>
		public void Validate()
		{
			if (StageActivityId == default)
				throw new InvalidStageActivityId();
			if (ExceptionCode.IsNullOrEmpty())
				throw new InvalidExceptionMessageCode();
			if (ExceptionMessage.IsNullOrEmpty())
				throw new InvalidExceptionMessage();
			if (BusinessProcess.IsNullOrEmpty())
				throw new InvalidBusinessProcessException();
		}
	}
}
