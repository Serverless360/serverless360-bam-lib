using System;
using Kovai.Serverless360.Bam;

namespace Kovai.Serverless360.Sample
{
	public static class Extension
	{
		public static bool IsValid(this StartActivityResponse activityResponse)
		{
			if (activityResponse.MainActivityId != Guid.Empty && activityResponse.StageActivityId != Guid.Empty)
				return true;
			return false;
		}
	}
}
