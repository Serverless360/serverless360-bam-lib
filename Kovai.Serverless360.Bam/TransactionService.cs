using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Kovai.Serverless360.Bam.Tests")]
namespace Kovai.Serverless360.Bam
{
    /// <summary>
    /// Provides a base class to send events to Serverless360 APIs.
    /// </summary>
    /// <seealso cref="Kovai.Serverless360.Bam.ITransactionService" />
    public class TransactionService : ITransactionService
    {
        private readonly string _key;
        private readonly string _url;
        private readonly HttpClient _client;

        /// <summary>Initializes a new instance of the <see cref="TransactionService"/> class.</summary>
        /// <param name="key">The key.</param>
        public TransactionService(string key)
        {
            _key = key;
            _url = Constants.FunctionUrlPattern;
            _client = new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="url">The URL.</param>
        public TransactionService(string key, string url)
        {
            _key = key;
            _url = url;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="client">The client.</param>
        internal TransactionService(string key, HttpClient client)
        {
            _key = key;
            _url = Constants.FunctionUrlPattern;
            _client = client;
        }

        /// <summary>
        /// Starts the transaction.
        /// </summary>
        /// <param name="transactionRequest">The transaction request.</param>
        /// <returns></returns>
        public async Task<StartTransactionResponse> StartTransaction(StartTransactionRequest transactionRequest)
        {
            var result = new StartTransactionResponse();
            try
            {
                transactionRequest.Validate();

                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, transactionRequest.BusinessProcess);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.Transaction, transactionRequest.Transaction);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.Stage, transactionRequest.Stage);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ArchiveMessage, Convert.ToString(transactionRequest.ArchiveMessage));
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageStatus, transactionRequest.StageStatus.ToString());
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionMessage, transactionRequest.ExceptionMessage);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionCode, transactionRequest.ExceptionCode);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BatchId, transactionRequest.BatchId);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.IsTransactionComplete, Convert.ToString(transactionRequest.IsTransactionComplete));

                if (transactionRequest.MessageHeader == null)
                    transactionRequest.MessageHeader = "{\"Content-Type\":\"application/json\"}";
                if (transactionRequest.MessageBody == null)
                    transactionRequest.MessageBody = "{}";

                var header = transactionRequest.MessageHeader.DeSerialize<Dictionary<string, string>>();
                header["Content-Type"] = "application/json";
                var body = new MessageContent
                {
                    MessageBody = transactionRequest.MessageBody,
                    MessageHeader = header.Serialize<Object>()
                };


                var uri = $"{_url}/api/{Constants.Operations.StartTransaction}?code={_key}";
                var data = body.Serialize();
                var response = await _client.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsJsonAsync<StartTransactionResponse>();
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        /// <summary>
        /// Check point Transaction.
        /// </summary>
        /// <param name="checkPointRequest">The check point request.</param>
        /// <returns></returns>
        public async Task<bool> CheckPoint(CheckPointRequest checkPointRequest)
        {
            try
            {
                checkPointRequest.Validate();

                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.TransactionInstanceId, checkPointRequest.TransactionInstanceId.ToString());
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.Stage, checkPointRequest.Stage);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageInstanceId, checkPointRequest.StageInstanceId.ToString());
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ArchiveMessage, Convert.ToString(checkPointRequest.ArchiveMessage));
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageStatus, checkPointRequest.StageStatus.ToString());
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionMessage, checkPointRequest.ExceptionMessage);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionCode, checkPointRequest.ExceptionCode);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BatchId, checkPointRequest.BatchId);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.IsTransactionComplete, Convert.ToString(checkPointRequest.IsTransactionComplete));


                if (checkPointRequest.MessageHeader == null)
                    checkPointRequest.MessageHeader = "{\"Content-Type\":\"application/json\"}";
                if (checkPointRequest.MessageBody == null)
                    checkPointRequest.MessageBody = "{}";

                var header = checkPointRequest.MessageHeader.DeSerialize<Dictionary<string, object>>();
                header["Content-Type"] = "application/json";
                var body = new MessageContent
                {
                    MessageBody = checkPointRequest.MessageBody,
                    MessageHeader = header.Serialize()
                };

                var uri = $"{_url}/api/{Constants.Operations.CheckPoint}?code={_key}";

                var data = body.Serialize();
                var content = await _client.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));
                return content.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        /// <summary>
        /// Correlation Check point Transaction.
        /// </summary>
        /// <param name="correlationcheckPointRequest">The correlation check point request.</param>
        /// <returns></returns>
        public async Task<bool> CorrelationCheckPoint(CorrelationCheckPointRequest correlationCheckPointRequest)
        {
            try
            {
                correlationCheckPointRequest.Validate();

                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.Stage, correlationCheckPointRequest.Stage);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageInstanceId, correlationCheckPointRequest.StageInstanceId.ToString());
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ArchiveMessage, Convert.ToString(correlationCheckPointRequest.ArchiveMessage));
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageStatus, correlationCheckPointRequest.StageStatus.ToString());
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionMessage, correlationCheckPointRequest.ExceptionMessage);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionCode, correlationCheckPointRequest.ExceptionCode);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BatchId, correlationCheckPointRequest.BatchId);
                _client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.IsTransactionComplete, Convert.ToString(correlationCheckPointRequest.IsTransactionComplete));


                if (correlationCheckPointRequest.MessageHeader == null)
                    correlationCheckPointRequest.MessageHeader = "{\"Content-Type\":\"application/json\"}";
                if (correlationCheckPointRequest.MessageBody == null)
                    correlationCheckPointRequest.MessageBody = "{}";
                if (correlationCheckPointRequest.CorrelationProperties == null)
                    correlationCheckPointRequest.CorrelationProperties = new Dictionary<string, object>();

                var header = correlationCheckPointRequest.MessageHeader.DeSerialize<Dictionary<string, object>>();
                header["Content-Type"] = "application/json";
                var body = new MessageContent
                {
                    MessageBody = correlationCheckPointRequest.MessageBody,
                    MessageHeader = header.Serialize(),
                    Property = JsonConvert.SerializeObject(correlationCheckPointRequest.CorrelationProperties.Select(c => new Property() { Name = c.Key, Value = c.Value }).ToList())
                };

                var uri = $"{_url}/api/{Constants.Operations.CheckPoint}?code={_key}";

                var data = body.Serialize();
                var content = await _client.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));
                return content.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
            }

            return false;
        }

    }
}