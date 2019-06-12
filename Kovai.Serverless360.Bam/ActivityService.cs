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
	/// <summary>
	/// Provides a base class to send activties to Serverless360 APIs.
	/// </summary>
	/// <seealso cref="Kovai.Serverless360.Bam.IActivityService" />
	public class ActivityService : IActivityService
	{
		private readonly string _key;
		private readonly string _url;
		private readonly IBamActivityLogger _bamActivityLogger;
		private readonly HttpClient _client;

		/// <summary>Initializes a new instance of the <see cref="ActivityService"/> class.</summary>
		/// <param name="key">The key.</param>
		public ActivityService(string key)
		{
			_key = key;
			_url = Constants.FunctionUrlPattern;
			_client = new HttpClient();
			_bamActivityLogger = new NullBamActivityLogger();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ActivityService"/> class.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="bamActivityLogger">The logger.</param>
		public ActivityService(string key, IBamActivityLogger bamActivityLogger)
		{
			_key = key;
			_url = Constants.FunctionUrlPattern;
			_bamActivityLogger = bamActivityLogger;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ActivityService"/> class.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="url">The URL.</param>
		public ActivityService(string key, string url)
		{
			_key = key;
			_url = url;
			_bamActivityLogger = new NullBamActivityLogger();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ActivityService"/> class.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="url">The URL.</param>
		/// <param name="bamActivityLogger">The logger.</param>
		public ActivityService(string key, string url, IBamActivityLogger bamActivityLogger)
		{
			_key = key;
			_url = url;
			_bamActivityLogger = bamActivityLogger;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ActivityService"/> class.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="client">The client.</param>
		internal ActivityService(string key, HttpClient client)
		{
			_key = key;
			_url = Constants.FunctionUrlPattern;
			_client = client;
			_bamActivityLogger = new NullBamActivityLogger();
		}


		/// <summary>
		/// Starts the activity.
		/// </summary>
		/// <param name="activityRequest">The activity request.</param>
		/// <returns></returns>
		public async Task<StartActivityResponse> StartActivity(StartActivityRequest activityRequest)
		{
			var result = new StartActivityResponse();
			try
			{
				activityRequest.Validate();

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
				
				if (activityRequest.PreviousStage.IsNullOrEmpty())
					activityRequest.PreviousStage = ".";

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
				_bamActivityLogger.Error(ex.Message);
			}
			return result;
		}

		/// <summary>
		/// Updates the activity.
		/// </summary>
		/// <param name="activityRequest">The activity request.</param>
		/// <returns></returns>
		public async Task<bool> UpdateActivity(UpdateActivityRequest activityRequest)
		{
			try
			{
				activityRequest.Validate();

				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessProcess, activityRequest.BusinessProcess);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.BusinessTransaction, activityRequest.BusinessTransaction);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.CurrentStage, activityRequest.CurrentStage);
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.MainActivityId, activityRequest.MainActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.StageActivityId, activityRequest.StageActivityId.ToString());
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.Status, Enum.GetName(typeof(StageStatus), activityRequest.Status));
				_client.DefaultRequestHeaders.AddOrReplace(Constants.Headers.ArchiveMessage, Convert.ToString(activityRequest.IsArchiveEnabled));


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
				_bamActivityLogger.Error(ex.Message);
			}

			return false;
		}

		/// <summary>
		/// Archives the activity.
		/// </summary>
		/// <param name="activityRequest">The activity request.</param>
		/// <returns></returns>
		public async Task<bool> ArchiveActivity(ArchiveActivityRequest activityRequest)
		{
			try
			{
				activityRequest.Validate();

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
				_bamActivityLogger.Error(ex.Message);
			}

			return false;
		}

		/// <summary>
		/// Logs the exception activity.
		/// </summary>
		/// <param name="activityRequest">The activity request.</param>
		/// <returns></returns>
		public async Task<bool> LogExceptionActivity(LogExceptionActivityRequest activityRequest)
		{
			try
			{
				activityRequest.Validate();

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
				_bamActivityLogger.Error(ex.Message);
			}

			return false;
		}
	}
}