using Kovai.Serverless360.Bam;

namespace Kovai.Serverless360.Sample
{
	class Program
	{

		static void Main(string[] args)
		{
			var processor = new LogisticsProcessor(new ActivityService("provide your key"));

			processor.SendBookingRequest();
			processor.ConfirmBooking();
			processor.SendShippingInstructions();
			processor.ReceiveInvoice();
		}


	}
}
