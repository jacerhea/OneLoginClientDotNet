using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneLogin.Descriptors;
using OneLogin.Requests;
using OneLogin.Responses;

namespace OneLogin
{
    public partial class OneLoginClient
    {
        /// <summary>
        /// Get all of the users registered with Onelogin.
        /// </summary>
        /// <returns>Returns the serialized <see cref="GetUsersResponse"/> as an asynchronous operation.</returns>
        [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-users")]
        public async Task<GetUsersResponse> GetUsers()
        {
            return await GetResource<GetUsersResponse>(Endpoints.ONELOGIN_USERS);
        }

        /// <summary>
        /// Get the Onelogin user.
        /// </summary>
        /// <param name="userId">the id of the user that you want to return.</param>
        /// <returns></returns>
        public async Task<GetUsersResponse> GetUser(int userId)
        {
            return await GetResource<GetUsersResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Set to the id of the user that you want to return.</param>
        /// <returns></returns>
        [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-apps-for-user")]
        public async Task<GetAppsForUserResponse> GetAppsForUser(int userId)
        {
            return await GetResource<GetAppsForUserResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/apps");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<GetRolesForUser> GetRolesForUser(int userId)
        {
            return await GetResource<GetRolesForUser>($"{Endpoints.ONELOGIN_USERS}/{userId}/roles");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GetCustomAttributesResponse> GetCustomAttributes()
        {
            return await GetResource<GetCustomAttributesResponse>($"{Endpoints.ONELOGIN_USERS}/custom_attributes");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetUsersResponse> CreateUser(CreateUserRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Endpoints.ONELOGIN_USERS),
                Content = content
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = await GetClient();
            var response = client.SendAsync(httpRequest);
            return await GetResponse<GetUsersResponse>(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetUsersResponse> UpdateUserById(UpdateUserRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request));
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Endpoints.ONELOGIN_USERS),
                Content = content
            };

            // We add the Content-Type Header like this because otherwise dotnet
            // adds the utf-8 charset extension to it which is not compatible with OneLogin
            httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = await GetClient();
            var response = client.SendAsync(httpRequest);
            return await GetResponse<GetUsersResponse>(response);
        }
    }
}
