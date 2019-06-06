#region Using Directives
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
#endregion

[assembly: InternalsVisibleTo("Kovai.Serverless360.Bam.Tests")]
namespace Kovai.Serverless360.Bam
{
	public class ActivityService : IActivityService
	{
		private readonly string _key;
		private readonly string _url;
		private readonly ILogger _logger;
		private readonly HttpClient _client;

		public ActivityService(string key)
		{
			_key = key;
			_url = Constants.FunctionUrlPattern;
			_client = new HttpClient();
			_logger = new NullLogger();
		}

		public ActivityService(string key, ILogger logger)
		{
			_key = key;
			_url = Constants.FunctionUrlPattern;
			_logger = logger;
		}

		public ActivityService(string key, string url)
		{
			_key = key;
			_url = url;
			_logger = new NullLogger();
		}

		public ActivityService(string key, string url, ILogger logger)
		{
			_key = key;
			_url = url;
			_logger = logger;
		}

		internal ActivityService(string key, HttpClient client)
		{
			_key = key;
			_url = Constants.FunctionUrlPattern;
			_client = client;
			_logger = new NullLogger();
		}


		public async Task<StartActivityResponse> StartActivity(StartActivityRequest activityRequest)
		{
			var result = new StartActivityResponse();
			try
			{
				if (!activityRequest.IsValid())
				{
					_logger.Error("Invalid start activity request");
					return result;
				}

				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, activityRequest.BusinessProcess);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessTransaction, activityRequest.BusinessTransaction);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.CurrentStage, activityRequest.CurrentStage);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.MainActivityId, activityRequest.MainActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.PreviousStage, activityRequest.PreviousStage);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ArchiveMessage, Convert.ToString(activityRequest.IsArchiveEnabled));
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BatchId, activityRequest.BatchId);

				if (activityRequest.MessageHeader == null)
					activityRequest.MessageHeader = "{\"Content-Type\":\"application/json\"}";
				if (activityRequest.MessageBody == null)
					activityRequest.MessageBody = "{}";

				var header = JsonConvert.DeserializeObject<Dictionary<string, object>>(activityRequest.MessageHeader);
				header["Content-Type"] = "application/json";
				var body = new
				{
					activityRequest.MessageBody,
					MessageHeader = JsonConvert.SerializeObject(header)
				};


				var uri = $"{_url}/api/{Constants.Operations.StartActivity}?code={_key}";
				var data = JsonConvert.SerializeObject(body);
				var response = await _client.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));
				if (response.IsSuccessStatusCode)
				{
					result = await response.Content.ReadAsJsonAsync<StartActivityResponse>();
				}

			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
			}
			return result;
		}

		public async Task<bool> UpdateActivity(UpdateActivityRequest activityRequest)
		{
			try
			{
				if (!activityRequest.IsValid())
				{
					_logger.Error("Invalid update activity request");
					return false;
				}

				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, activityRequest.BusinessProcess);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessTransaction, activityRequest.BusinessTransaction);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.CurrentStage, activityRequest.CurrentStage);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.MainActivityId, activityRequest.MainActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageActivityId, activityRequest.StageActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.Status, Enum.GetName(typeof(StageStatus), activityRequest.Status));
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.IsArchiveEnabled, Convert.ToString(activityRequest.IsArchiveEnabled));


				if (activityRequest.MessageHeader == null)
					activityRequest.MessageHeader = "{\"Content-Type\":\"application/json\"}";
				if (activityRequest.MessageBody == null)
					activityRequest.MessageBody = "{}";

				var header = JsonConvert.DeserializeObject<Dictionary<string, object>>(activityRequest.MessageHeader);
				header["Content-Type"] = "application/json";
				var body = new
				{
					activityRequest.MessageBody,
					MessageHeader = JsonConvert.SerializeObject(header)
				};

				var uri = $"{_url}/api/{Constants.Operations.UpdateActivity}?code={_key}";

				var data = JsonConvert.SerializeObject(body);
				var content = await _client.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));
				return content.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
			}

			return false;
		}

		public async Task<bool> ArchiveActivity(ArchiveActivityRequest activityRequest)
		{
			try
			{
				if (!activityRequest.IsValid())
				{
					_logger.Error("Invalid archive activity request");
					return false;
				}

				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, activityRequest.BusinessProcess);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessTransaction, activityRequest.BusinessTransaction);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.CurrentStage, activityRequest.CurrentStage);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageActivityId, activityRequest.StageActivityId.ToString());


				if (activityRequest.MessageHeader == null)
					activityRequest.MessageHeader = "{\"Content-Type\":\"application/json\"}";
				if (activityRequest.MessageBody == null)
					activityRequest.MessageBody = "{}";

				var header = JsonConvert.DeserializeObject<Dictionary<string, object>>(activityRequest.MessageHeader);
				header["Content-Type"] = "application/json";
				var body = new
				{
					activityRequest.MessageBody,
					MessageHeader = JsonConvert.SerializeObject(header)
				};

				var uri = $"{_url}/api/{Constants.Operations.ArchiveActivity}?code={_key}";
				var data = JsonConvert.SerializeObject(body);
				var content = await _client.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));
				return content.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
			}

			return false;
		}

		public async Task<bool> LogExceptionActivity(LogExceptionActivityRequest activityRequest)
		{
			try
			{
				if (!activityRequest.IsValid())
				{
					_logger.Error("Invalid log exception activity request");
					return false;
				}

				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageActivityId, activityRequest.StageActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, activityRequest.BusinessProcess);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionCode, activityRequest.ExceptionCode);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ExceptionMessage, activityRequest.ExceptionMessage);


				var uri = $"{_url}/api/{Constants.Operations.LogExceptionActivity}?code={_key}";

				var content = await _client.PostAsync(uri, null);
				return content.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
			}

			return false;
		}
	}
}