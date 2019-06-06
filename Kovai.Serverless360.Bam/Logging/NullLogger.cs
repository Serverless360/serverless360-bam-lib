namespace Kovai.Serverless360.Bam
{
	public class NullLogger : ILogger
	{
		public void Debug(string message)
		{
			//do nothing
		}

		public void Info(string message)
		{
			//do nothing
		}

		public void Warning(string message)
		{
			//do nothing
		}

		public void Error(string message)
		{
			//do nothing
		}

		public void Fatal(string message)
		{
			//do nothing
		}
	}
}
