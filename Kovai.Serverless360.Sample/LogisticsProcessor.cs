using Kovai.Serverless360.Bam;

namespace Kovai.Serverless360.Sample
{
    public class LogisticsProcessor
    {
        private readonly ITransactionService _service;
        private readonly string _businessProcess;

        public LogisticsProcessor(ITransactionService service)
        {
            _service = service;
            _businessProcess = "Ship Any Where Logistics";
        }

        public void SendBookingRequest()
        {
            var businessTransaction = "Booking Request";

            //Receive

            var receiveResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Receive",
                ArchiveMessage = true,
                MessageBody = "{\"tim\":1}",
                MessageHeader = "",
            }).Result;

            if (receiveResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Receive",
                    TransactionInstanceId = receiveResponse.TransactionInstanceId,
                    StageInstanceId = receiveResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}",
                });
            }

            //Process

            var processResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Process",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}",
            }).Result;

            if (processResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Process",
                    TransactionInstanceId = processResponse.TransactionInstanceId,
                    StageInstanceId = processResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}",
                });
            }

            //Send

            var sendResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Send",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}",
            }).Result;

            if (sendResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Send",
                    TransactionInstanceId = sendResponse.TransactionInstanceId,
                    StageInstanceId = sendResponse.StageInstanceId,
                    StageStatus
                    = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}",
                });
            }
        }

        public void ConfirmBooking()
        {
            var businessTransaction = "Confirm Booking";

            //Receive

            var receiveResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Receive",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}",
            }).Result;

            if (receiveResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Receive",
                    TransactionInstanceId = receiveResponse.TransactionInstanceId,
                    StageInstanceId = receiveResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}",
                });

            }
            //Process

            var processResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Process",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}"
            }).Result;

            if (processResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Process",
                    TransactionInstanceId = processResponse.TransactionInstanceId,
                    StageInstanceId = processResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}"
                });
            }
            //Send

            var sendResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Send",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}"
            }).Result;

            if (sendResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Send",
                    TransactionInstanceId = sendResponse.TransactionInstanceId,
                    StageInstanceId = sendResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}"
                });
            }
        }

        public void SendShippingInstructions()
        {
            var businessTransaction = "Send Shipping Instructions";

            //Receive

            var receiveResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Receive",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}"
            }).Result;

            if (receiveResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Receive",
                    TransactionInstanceId = receiveResponse.TransactionInstanceId,
                    StageInstanceId = receiveResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}"
                });


                _service.CorrelationCheckPoint(new CorrelationCheckPointRequest()
                {
                    CorrelationProperties = new System.Collections.Generic.Dictionary<string, object>(),
                    Stage = "Receive",
                    StageInstanceId = receiveResponse.StageInstanceId,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}"
                });
            }
            //Process

            var processResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Process",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}"
            }).Result;

            if (processResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Process",
                    TransactionInstanceId = processResponse.TransactionInstanceId,
                    StageInstanceId = processResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}"
                });

            }
            //Send

            var sendResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Send",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}"
            }).Result;


            if (sendResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Send",
                    TransactionInstanceId = sendResponse.TransactionInstanceId,
                    StageInstanceId = sendResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}"
                });
            }
        }

        public void ReceiveInvoice()
        {
            var businessTransaction = "Receive Invoice";

            //Receive

            var receiveResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Receive",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}"
            }).Result;

            if (receiveResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Receive",
                    TransactionInstanceId = receiveResponse.TransactionInstanceId,
                    StageInstanceId = receiveResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}"
                });

            }
            //Process

            var processResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Process",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}"
            }).Result;

            if (processResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Process",
                    TransactionInstanceId = processResponse.TransactionInstanceId,
                    StageInstanceId = processResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}"
                });

            }
            //Send

            var sendResponse = _service.StartTransaction(new StartTransactionRequest
            {
                BusinessProcess = _businessProcess,
                Transaction = businessTransaction,
                Stage = "Send",
                MessageBody = "{\"some\":1}",
                MessageHeader = "{\"some\":1}"
            }).Result;

            if (sendResponse.IsValid())
            {
                _service.CheckPoint(new CheckPointRequest()
                {
                    Stage = "Send",
                    TransactionInstanceId = sendResponse.TransactionInstanceId,
                    StageInstanceId = sendResponse.StageInstanceId,
                    StageStatus = StageStatus.Success,
                    MessageBody = "{\"some\":1}",
                    MessageHeader = "{\"some\":1}"
                });
            }
        }
    }
}