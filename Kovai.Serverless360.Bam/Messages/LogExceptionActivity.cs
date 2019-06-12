#region Using Directives
using System;
#endregion

namespace Kovai.Serverless360.Bam
{
	public class LogExceptionActivityRequest
	{
		/// <summary>
		/// Gets or sets the stage activity identifier.
		/// </summary>
		/// <value>
		/// The stage activity identifier.
		/// </value>
		public Guid StageActivityId { get; set; }
		/// <summary>
		/// Gets or sets the exception message.
		/// </summary>
		/// <value>
		/// The exception message.
		/// </value>
		public string ExceptionMessage { get; set; }
		/// <summary>
		/// Gets or sets the exception code.
		/// </summary>
		/// <value>
		/// The exception code.
		/// </value>
		public string ExceptionCode { get; set; }
		/// <summary>
		/// Gets or sets the business process.
		/// </summary>
		/// <value>
		/// The business process.
		/// </value>
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
