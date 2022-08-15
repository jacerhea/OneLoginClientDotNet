using OneLogin.Requests;
using OneLogin.Responses;
using OneLogin.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneLogin
{
    public partial class OneLoginClient
    {
		public async Task<GetAppsResponse> GetApps(string name = null, int? connectorId = null, AppAuthMethod? authMethod = null)
		{
			var parameters = new Dictionary<string, string>
				{
					{"name", name},
					{"connector_id", connectorId.HasValue ? connectorId.ToString() : string.Empty},
					{"auth_method", authMethod.HasValue ? authMethod.ToString() : string.Empty}
				};
			return await GetResource<GetAppsResponse>($"/{Endpoints.API}{Endpoints.ApiVersion2}{Endpoints.ONELOGIN_APPS}", parameters);
		}

		public async Task<AppDetail> GetAppById(int appId)
		{
			return await GetResource<AppDetail>($"/{Endpoints.API}{Endpoints.ApiVersion2}{Endpoints.ONELOGIN_APPS}/{appId}");
		}

		public async Task<AppDetail> UpdateApp(UpdateAppRequest app)
		{
			return await PutResource<AppDetail>($"/{Endpoints.API}{Endpoints.ApiVersion2}{Endpoints.ONELOGIN_APPS}/{app.Id}", app);
		}

		public async Task<AppDetail> CreateApp(CreateAppRequest app)
		{
			return await PostResource<AppDetail>($"/{Endpoints.API}{Endpoints.ApiVersion2}{Endpoints.ONELOGIN_APPS}", app);
		}
	}
}
