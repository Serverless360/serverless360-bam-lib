#region Using Directives
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
#endregion

namespace Kovai.Serverless360.Bam
{
	public static class Extensions
	{
		public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content) where T : class
		{
			try
			{
				var contentStr = await content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(contentStr);
			}
			catch (Exception ex)
			{
				return default;
			}
		}

		public static void AddOrReplace(this HttpRequestHeaders headers, string name, string value)
		{
			if (headers.Contains(name))
				headers.Remove(name);
			headers.Add(name, value);
		}
	}
}