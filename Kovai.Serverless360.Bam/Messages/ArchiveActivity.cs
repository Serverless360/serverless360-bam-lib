#region Using Directives
using System;
#endregion

namespace Kovai.Serverless360.Bam
{
	public class ArchiveActivityRequest
	{
		/// <summary>
		/// Gets or sets the business process.
		/// </summary>
		/// <value>
		/// The business process.
		/// </value>
		public string BusinessProcess { get; set; }
		/// <summary>
		/// Gets or sets the business transaction.
		/// </summary>
		/// <value>
		/// The business transaction.
		/// </value>
		public string BusinessTransaction { get; set; }
		/// <summary>
		/// Gets or sets the current stage.
		/// </summary>
		/// <value>
		/// The current stage.
		/// </value>
		public string CurrentStage { get; set; }
		/// <summary>
		/// Gets or sets the stage activity identifier.
		/// </summary>
		/// <value>
		/// The stage activity identifier.
		/// </value>
		public Guid StageActivityId { get; set; }
		/// <summary>
		/// Gets or sets the message body.
		/// </summary>
		/// <value>
		/// The message body.
		/// </value>
		public string MessageBody { get; set; }
		/// <summary>
		/// Gets or sets the message header.
		/// </summary>
		/// <value>
		/// The message header.
		/// </value>
		public string MessageHeader { get; set; }


		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <exception cref="Kovai.Serverless360.Bam.InvalidBusinessProcessException"></exception>
		/// <exception cref="Kovai.Serverless360.Bam.InvalidBusinessTransactionException"></exception>
		/// <exception cref="Kovai.Serverless360.Bam.InvalidStageNameException"></exception>
		/// <exception cref="InvalidStageActivityId"></exception>
		public void Validate()
		{
			if (BusinessProcess.IsNullOrEmpty())
				throw new InvalidBusinessProcessException();
			if (BusinessTransaction.IsNullOrEmpty())
				throw new InvalidBusinessTransactionException();
			if (CurrentStage.IsNullOrEmpty())
				throw new InvalidStageNameException();
			if (StageActivityId == default)
				throw new InvalidStageActivityId();

		}
	}
}