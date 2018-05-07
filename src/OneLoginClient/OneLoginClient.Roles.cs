using System.Threading.Tasks;
using OneLogin.Responses;

namespace OneLogin
{
    public partial class OneLoginClient
    {
        /// <summary>
        /// Use this call to get a role by ID.
        /// </summary>
        /// <param name="id">Set to the id of the role that you want to return. If you don’t know the role’s  id, use the Get Roles API call to return all roles and their id values.</param>
        /// <returns></returns>
        public async Task<GetRoleResponse> GetRole(int id)
        {
            return await GetResource<GetRoleResponse>($"{Endpoints.ONELOGIN_ROLES}/{id}");
        }

        /// <summary>
        /// This call returns up to 50 roles per page.
        /// </summary>
        /// <returns></returns>
        public async Task<GetRolesResponse> GetRoles()
        {
            return await GetResource<GetRolesResponse>($"{Endpoints.ONELOGIN_ROLES}");
        }
    }
}
