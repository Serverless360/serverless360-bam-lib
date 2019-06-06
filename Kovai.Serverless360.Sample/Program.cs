using Kovai.Serverless360.Bam;

namespace Kovai.Serverless360.Sample
{
	class Program
	{

		static void Main(string[] args)
		{
			var processor = new LogisticsProcessor(new ActivityService("lvYumFPPr6RNjWX99kqPHpPun75b3WOkNTz6QlQ8YDD3yAQAJRvuxg=="));

			processor.SendBookingRequest();
		}


	}
}
