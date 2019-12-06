using Kovai.Serverless360.Bam;
using Microsoft.Extensions.Configuration;

namespace Kovai.Serverless360.Sample
{
	class Program
	{
		static void Main()
		{
			var processor = new LogisticsProcessor(new TransactionService("ggDoKMKQF0BDDeNYyImfxgvhzOQ72u7fgQUixQguZqf94pwqyUpiTg"));
			processor.SendBookingRequest();
			processor.ConfirmBooking();
			processor.SendShippingInstructions();
			processor.ReceiveInvoice();
		}
	}
}