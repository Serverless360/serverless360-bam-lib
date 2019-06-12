namespace Kovai.Serverless360.Bam
{
	public class Constants
	{
#if DEBUG
		public const string FunctionUrlPattern = "https://sl360-bam.azurewebsites.net";
#else
   public const string FunctionUrlPattern = "https://sl360-prod-BAM-functionapp.azurewebsites.net";
#endif
		
		internal class Headers
		{
			public const string BusinessProcess = "SL360-BusinessProcess";
			public const string BusinessTransaction = "SL360-BusinessTransaction";
			public const string CurrentStage = "SL360-CurrentStage";
			public const string MainActivityId = "SL360-MainActivityId";
			public const string StageActivityId = "SL360-StageActivityId";
			public const string PreviousStage = "SL360-PreviousStage";
			public const string ArchiveMessage = "SL360-ArchiveMessage";
			public const string BatchId = "SL360-BatchId";
			public const string Status = "SL360-Status";
			public const string ExceptionMessage = "SL360-ExceptionMessage";
			public const string ExceptionCode = "SL360-ExceptionCode";
		}

		internal class Operations
		{
			public const string StartActivity = "StartActivity";
			public const string UpdateActivity = "UpdateActivity";
			public const string ArchiveActivity = "ArchiveActivity";
			public const string LogExceptionActivity = "LogExceptionActivity";
		}
	}
}
