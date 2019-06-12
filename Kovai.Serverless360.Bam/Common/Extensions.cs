#region Using Directives
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
#endregion

namespace Kovai.Serverless360.Bam
{
	internal static class Extensions
	{
		internal static async Task<T> ReadAsJsonAsync<T>(this HttpContent content) where T : class
		{
			try
			{
				var contentStr = await content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(contentStr);
			}
			catch (Exception)
			{
				return default;
			}
		}

		internal static void AddOrReplace(this HttpRequestHeaders headers, string name, string value)
		{
			if (headers.Contains(name))
				headers.Remove(name);
			headers.Add(name, value);
		}

		internal static bool IsNotNullOrEmpty(this string str)
		{
			return !string.IsNullOrEmpty(str);
		}
		internal static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}
	}
}