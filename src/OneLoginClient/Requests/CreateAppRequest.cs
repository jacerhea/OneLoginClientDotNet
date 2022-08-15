using OneLogin.Types;
using System;

namespace OneLogin.Requests
{
	public class CreateAppRequest : AppDetail
	{
		public CreateAppRequest(int connectorId, string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException(nameof(name), "Name is required");
			}

			ConnectorId = connectorId;
			Name = name;
		}
	}
}
