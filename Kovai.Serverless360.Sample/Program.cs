using Kovai.Serverless360.Bam;

namespace Kovai.Serverless360.Sample
{
	class Program
	{

		static void Main(string[] args)
		{
			var processor = new LogisticsProcessor(new ActivityService("V9sOiZ6eE0jDjq25zFpKEzejlk2jAija4cCqU290b15qcoi8/iynvw=="));

			processor.SendBookingRequest();
			processor.ConfirmBooking();
			processor.SendShippingInstructions();
			processor.ReceiveInvoice();
		}


	}
}
