#region Using Directives
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;
#endregion

namespace Kovai.Serverless360.Bam.Tests
{
	public class ActivityTests
	{
		private const string Key = "h1XqRO8J1tbkHABsfxQEYdGPNYzDX1i3kHzqIpXh4albzaXKesbNDg==";
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
				.StartActivity(new StartActivityRequest()).Result;

			Assert.NotNull((object)result);
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
			var response = activityService.UpdateActivity(new UpdateActivityRequest()).Result;

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
			var response = activityService.ArchiveActivity(new ArchiveActivityRequest()).Result;

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
			var response = activityService.LogExceptionActivity(new LogExceptionActivityRequest()).Result;

			//Assert
			Assert.True(response);
		}
	}
}
