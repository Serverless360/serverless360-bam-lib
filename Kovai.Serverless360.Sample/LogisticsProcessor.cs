using Kovai.Serverless360.Bam;

namespace Kovai.Serverless360.Sample
{
	public class LogisticsProcessor
	{
		private readonly IActivityService _service;
		private readonly string _businessProcess;

		public LogisticsProcessor(IActivityService service)
		{
			_service = service;
			_businessProcess = "ShipAnyWhereLogistics";
		}

		public void SendBookingRequest()
		{
			var businessTransaction = "Booking Request";

			//Receive

			var receiveResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = "."
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				MainActivityId = receiveResponse.MainActivityId,
				StageActivityId = receiveResponse.StageActivityId,
				Status = StageStatus.Success
			});

			//Process

			var processResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive"
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = processResponse.MainActivityId,
				StageActivityId = processResponse.StageActivityId,
				Status = StageStatus.Success
			});

			//Send
			
			var sendResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process"
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = sendResponse.MainActivityId,
				StageActivityId = sendResponse.StageActivityId,
				Status = StageStatus.Success
			});
		}

		public void ConfirmBooking()
		{
			var businessTransaction = "Confirm Booking";

			//Receive

			var receiveResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = "."
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				MainActivityId = receiveResponse.MainActivityId,
				StageActivityId = receiveResponse.StageActivityId,
				Status = StageStatus.Success
			});

			//Process

			var processResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive"
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = processResponse.MainActivityId,
				StageActivityId = processResponse.StageActivityId,
				Status = StageStatus.Success
			});

			//Send
			
			var sendResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process"
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = sendResponse.MainActivityId,
				StageActivityId = sendResponse.StageActivityId,
				Status = StageStatus.Success
			});
		}

		public void SendShippingInstructions()
		{
			var businessTransaction = "Send Shipping Instructions";

			//Receive

			var receiveResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = "."
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				MainActivityId = receiveResponse.MainActivityId,
				StageActivityId = receiveResponse.StageActivityId,
				Status = StageStatus.Success
			});

			//Process

			var processResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive"
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = processResponse.MainActivityId,
				StageActivityId = processResponse.StageActivityId,
				Status = StageStatus.Success
			});

			//Send
			
			var sendResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process"
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = sendResponse.MainActivityId,
				StageActivityId = sendResponse.StageActivityId,
				Status = StageStatus.Success
			});
		}

		public void ReceiveInvoice()
		{
			var businessTransaction = "Receive Invoice";

			//Receive

			var receiveResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				PreviousStage = "."
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Receive",
				MainActivityId = receiveResponse.MainActivityId,
				StageActivityId = receiveResponse.StageActivityId,
				Status = StageStatus.Success
			});

			//Process

			var processResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Receive"
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Process",
				MainActivityId = processResponse.MainActivityId,
				StageActivityId = processResponse.StageActivityId,
				Status = StageStatus.Success
			});

			//Send
			
			var sendResponse = _service.StartActivity(new StartActivityRequest
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = receiveResponse.MainActivityId,
				PreviousStage = "Process"
			}).Result;

			_service.UpdateActivity(new UpdateActivityRequest()
			{
				BusinessProcess = _businessProcess,
				BusinessTransaction = businessTransaction,
				CurrentStage = "Send",
				MainActivityId = sendResponse.MainActivityId,
				StageActivityId = sendResponse.StageActivityId,
				Status = StageStatus.Success
			});
		}


	}
}