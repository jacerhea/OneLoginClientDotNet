using System.Threading.Tasks;
using OneLogin.Responses;

namespace OneLogin
{
    public partial class OneLoginClient
    {
        /// <summary>
        /// Use to get a list of groups that are available in your account. The call returns up to 50 groups per page.
        /// </summary>
        /// <returns></returns>
        public async Task<GetGroupsResponse> GetGroups()
        {
            return await GetResource<GetGroupsResponse>(Endpoints.ONELOGIN_GROUPS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Set to the group’s ID with .xml appended. For example, 123456.xml. If you don’t know the group’s id, use the Get all groups API call to return all groups and their id values.</param>
        /// <returns></returns>
        //todo: onelogin documentation is wrong.
        public async Task<GetGroupsResponse> GetGroup(int id)
        {
            return await GetResource<GetGroupsResponse>($"{Endpoints.ONELOGIN_GROUPS}/{id}");
        }
    }
}
