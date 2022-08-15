using OneLogin.Types;
using System;

namespace OneLogin.Requests
{
	public class UpdateAppRequest : AppDetail
	{
		public UpdateAppRequest(int appId)
		{
			if (appId <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(appId), "App Id is required in app parameter");
			}

			Id = appId;
		}
	}
}
