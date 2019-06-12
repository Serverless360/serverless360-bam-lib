using Kovai.Serverless360.Bam;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Kovai.Serverless360.Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			IConfiguration config = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json", true, true)
					.Build();
			var processor = new LogisticsProcessor(new ActivityService(config["code"]));

			processor.SendBookingRequest();
			processor.ConfirmBooking();
			processor.SendShippingInstructions();
			processor.ReceiveInvoice();
		}
	}
}
