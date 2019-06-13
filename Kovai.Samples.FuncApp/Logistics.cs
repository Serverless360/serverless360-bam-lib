using System.Threading.Tasks;
using Kovai.Serverless360.Bam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Kovai.Samples.FuncApp
{
	public static class Logistics
	{
		[FunctionName("BookingRequest")]
		public static async Task<IActionResult> Run(
				[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
				ILogger log)
		{
			log.LogInformation("C# HTTP trigger function processed a request.");

			IActivityService service = new ActivityService("V9sOiZ6eE0jDjq25zFpKEzejlk2jAija4cCqU290b15qcoi8/iynvw==");
			var response = await service.StartActivity(new StartActivityRequest()
			{
				BusinessProcess = "Ship Any Where Logistics",
				BusinessTransaction = "Booking Request",
				CurrentStage = "Receive",
				PreviousStage = ".",
				IsArchiveEnabled = true,
				MessageBody = "{\"some\":1}",
				MessageHeader = "{\"some\":1}",
			});

			return new OkObjectResult(response);
		}
	}
}
