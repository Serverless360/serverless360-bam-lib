#region Using Directives
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Xunit;
#endregion

namespace Kovai.Serverless360.Bam.Tests
{
	public class ActivityTests
	{
		private const string Key = "provide your key";
		public ActivityTests()
		{

		}

		[Fact]
		public void TestStartActivity()
		{
			var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
			handlerMock
				.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(new HttpResponseMessage()
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(JsonConvert.SerializeObject(new StartActivityResponse()
					{
						MainActivityId = Guid.NewGuid(),
						StageActivityId = Guid.NewGuid()
					}))
				})
				.Verifiable();

			var httpClient = new HttpClient(handlerMock.Object)
			{
				BaseAddress = new Uri("http://test.com/")
			};

			IActivityService activityService = new ActivityService(Key, httpClient);

			var result = activityService
				.StartActivity(
					new StartActivityRequest
					{
						BusinessProcess = "Test",
						BusinessTransaction = "Test",
						CurrentStage = "Test",
						MessageBody = "Test",
						MessageHeader = "{\"some\":1}"
					}).Result;

			Assert.NotNull(result);
		}

		[Theory]

		[InlineData("", "Test", "Test", "Test", "Test")]
		[InlineData("Test", "", "Test", "Test", "Test")]
		[InlineData("Test", "Test", "", "Test", "Test")]
		[InlineData("Test", "Test", "Test", "", "Test")]
		[InlineData("Test", "Test", "Test", "Test", "")]
		public void TestNegativeScenarios(string businessProcess, string businessTransaction, string currentStage, string messageBody, string messageHeader)
		{
			var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
			handlerMock
				.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(new HttpResponseMessage()
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(JsonConvert.SerializeObject(new StartActivityResponse()
					{
						MainActivityId = Guid.NewGuid(),
						StageActivityId = Guid.NewGuid()
					}))
				})
				.Verifiable();

			var httpClient = new HttpClient(handlerMock.Object)
			{
				BaseAddress = new Uri("http://test.com/")
			};

			IActivityService activityService = new ActivityService(Key, httpClient);
			var result = activityService
				.StartActivity(new StartActivityRequest()
				{
					BusinessProcess = businessProcess,
					BusinessTransaction = businessTransaction,
					CurrentStage = currentStage,
					MessageBody = messageBody,
					MessageHeader = messageHeader
				}).Result;

			Assert.True(result.StageActivityId == default);
		}

		[Fact]
		public void TestUpdateActivity()
		{
			//Arrange
			var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
			handlerMock
				.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(new HttpResponseMessage()
				{
					StatusCode = HttpStatusCode.OK
				})
				.Verifiable();

			var httpClient = new HttpClient(handlerMock.Object)
			{
				BaseAddress = new Uri("http://test.com/")
			};

			IActivityService activityService = new ActivityService(Key, httpClient);

			//Act
			var response = activityService.UpdateActivity(new UpdateActivityRequest(){
				MessageBody = "Test",
				MessageHeader = "{\"some\":1}",
				MainActivityId = Guid.NewGuid(),
				StageActivityId = Guid.NewGuid(),
				BusinessTransaction = "Test",
				BusinessProcess = "Test",
				CurrentStage = "Test"
				}).Result;

			//Assert
			Assert.True(response);
		}



		[Fact]
		public void TestArchiveActivity()
		{
			//Arrange
			var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
			handlerMock
				.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(new HttpResponseMessage()
				{
					StatusCode = HttpStatusCode.OK
				})
				.Verifiable();

			var httpClient = new HttpClient(handlerMock.Object)
			{
				BaseAddress = new Uri("http://test.com/")
			};

			IActivityService activityService = new ActivityService(Key, httpClient);

			//Act
			var response = activityService.ArchiveActivity(new ArchiveActivityRequest()
			{
				BusinessProcess = "Test",
				BusinessTransaction = "Test",
				CurrentStage = "Test",
				MessageBody = "Test",
				MessageHeader = "{\"some\":1}",
				StageActivityId = Guid.NewGuid()
			}).Result;

			//Assert
			Assert.True(response);
		}

		[Fact]
		public void TestLogExceptionActivity()
		{
			//Arrange
			var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
			handlerMock
				.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(new HttpResponseMessage()
				{
					StatusCode = HttpStatusCode.OK
				})
				.Verifiable();

			var httpClient = new HttpClient(handlerMock.Object)
			{
				BaseAddress = new Uri("http://test.com/")
			};

			IActivityService activityService = new ActivityService(Key, httpClient);

			//Act
			var response = activityService.LogExceptionActivity(new LogExceptionActivityRequest()
			{
				BusinessProcess = "Test",
				ExceptionCode = "Test",
				ExceptionMessage = "Test",
				StageActivityId = Guid.NewGuid()
			}).Result;

			//Assert
			Assert.True(response);
		}
	}
}
