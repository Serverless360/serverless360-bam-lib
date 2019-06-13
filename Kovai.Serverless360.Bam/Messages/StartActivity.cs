#region Using Directives
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

#endregion

namespace Kovai.Serverless360.Bam
{
	public class StartActivityRequest
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
		/// Gets or sets a value indicating whether this instance is archive enabled.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is archive enabled; otherwise, <c>false</c>.
		/// </value>
		[DataMember]
		public bool IsArchiveEnabled { get; set; }
		/// <summary>
		/// Gets or sets the batch identifier.
		/// </summary>
		/// <value>
		/// The batch identifier.
		/// </value>
		[DataMember]
		public string BatchId { get; set; }
		/// <summary>
		/// Gets or sets the main activity identifier.
		/// </summary>
		/// <value>
		/// The main activity identifier.
		/// </value>
		[DataMember]
		public Guid? MainActivityId { get; set; }
		/// <summary>
		/// Gets or sets the previous stage.
		/// </summary>
		/// <value>
		/// The previous stage.
		/// </value>
		[DataMember]
		public string PreviousStage { get; set; }

		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <exception cref="InvalidMessageBody"></exception>
		/// <exception cref="InvalidMessageHeader"></exception>
		/// <exception cref="Kovai.Serverless360.Bam.InvalidBusinessProcessException"></exception>
		/// <exception cref="Kovai.Serverless360.Bam.InvalidBusinessTransactionException"></exception>
		/// <exception cref="Kovai.Serverless360.Bam.InvalidStageNameException"></exception>
		public void Validate()
		{
			if (MessageBody.IsNullOrEmpty()) throw new InvalidMessageBody();
			if (MessageHeader.IsNullOrEmpty()) throw new InvalidMessageHeader();
			if (BusinessProcess.IsNullOrEmpty()) throw new InvalidBusinessProcessException();
			if (BusinessTransaction.IsNullOrEmpty()) throw new InvalidBusinessTransactionException();
			if (CurrentStage.IsNullOrEmpty()) throw new InvalidStageNameException();

		}
	}

	[DataContract]
	public class StartActivityResponse
	{
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
	}
}