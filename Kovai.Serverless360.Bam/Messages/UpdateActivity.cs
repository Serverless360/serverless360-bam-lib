#region Using Directives
using System;
using System.Runtime.Serialization;

#endregion

namespace Kovai.Serverless360.Bam
{
	[DataContract]
	public class UpdateActivityRequest
	{
		/// <summary>
		/// Gets or sets the business process.
		/// </summary>
		/// <value>
		/// The business process.
		/// </value>
		[DataMember]
		public string BusinessProcess { get; set; }
		/// <summary>
		/// Gets or sets the business transaction.
		/// </summary>
		/// <value>
		/// The business transaction.
		/// </value>
		[DataMember]
		public string BusinessTransaction { get; set; }
		/// <summary>
		/// Gets or sets the current stage.
		/// </summary>
		/// <value>
		/// The current stage.
		/// </value>
		[DataMember]
		public string CurrentStage { get; set; }
		/// <summary>
		/// Gets or sets the message body.
		/// </summary>
		/// <value>
		/// The message body.
		/// </value>
		[DataMember]
		public string MessageBody { get; set; }
		/// <summary>
		/// Gets or sets the message header.
		/// </summary>
		/// <value>
		/// The message header.
		/// </value>
		[DataMember]
		public string MessageHeader { get; set; }
		/// <summary>
		/// Gets or sets the main activity identifier.
		/// </summary>
		/// <value>
		/// The main activity identifier.
		/// </value>
		[DataMember]
		public Guid MainActivityId { get; set; }
		/// <summary>
		/// Gets or sets the stage activity identifier.
		/// </summary>
		/// <value>
		/// The stage activity identifier.
		/// </value>
		[DataMember]
		public Guid StageActivityId { get; set; }
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		[DataMember]
		public StageStatus Status { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this instance is archive enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is archive enabled; otherwise, <c>false</c>.
		/// </value>
		[DataMember]
		public bool IsArchiveEnabled { get; set; }

		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <exception cref="InvalidMessageBody"></exception>
		/// <exception cref="InvalidMessageHeader"></exception>
		/// <exception cref="InvalidMainActivityId"></exception>
		/// <exception cref="InvalidStageActivityId"></exception>
		/// <exception cref="InvalidBusinessTransactionException">
		/// </exception>
		/// <exception cref="InvalidStageNameException"></exception>
		public void Validate()
		{
			if(MessageBody.IsNullOrEmpty())
				throw new InvalidMessageBody();
			if(MessageHeader.IsNullOrEmpty())
				throw new InvalidMessageHeader();
			if(MainActivityId == default)
				throw new InvalidMainActivityId();
			if(StageActivityId == default)
				throw new InvalidStageActivityId();
			if(BusinessTransaction.IsNullOrEmpty())
				throw new InvalidBusinessTransactionException();
			if(BusinessProcess.IsNullOrEmpty())
				throw new InvalidBusinessTransactionException();
			if(CurrentStage.IsNullOrEmpty())
				throw new InvalidStageNameException();
		}
	}
}