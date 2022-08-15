using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneLogin.Requests;
using OneLogin.Responses;

namespace OneLogin
{
    public partial class OneLoginClient
    {
        /// <summary>
        /// Get all of the users registered with OneLogin filtered by the given parameters.
        /// https://developers.onelogin.com/api-docs/1/users/get-users
        /// </summary>
        /// <returns>Returns the serialized <see cref="GetUsersResponse"/> as an asynchronous operation.</returns>
        public async Task<GetUsersResponse> GetUsers(string directoryId = null, string email = null, string externalId = null,
            string firstName = null, string managerAdId = null, int? roleId = null, string samAccountName = null, DateTime? since = null,
            DateTime? until = null, string userName = null, string userPrincipalName = null)
        {
            var parameters = new Dictionary<string, string>
                {
                    {"directory_id", directoryId},
                    {"email", email},
                    {"external_id", externalId},
                    {"firstname", firstName},
                    {"manager_ad_id", managerAdId},
                    {"role_id", roleId.ToString()},
                    {"samaccountname", samAccountName},
                    {"since", since.ToString()},
                    {"until", until.ToString()},
                    {"username", userName},
                    {"userprincipalname", userPrincipalName}
                };

            return await GetResource<GetUsersResponse>(Endpoints.ONELOGIN_USERS, parameters);
        }

        /// <summary>
        /// Get the Onelogin user.
        /// </summary>
        /// <param name="userId">the id of the user that you want to return.</param>
        /// <returns></returns>
        public async Task<GetUserResponse> GetUserById(int userId)
        {
            return await GetResource<GetUserResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}");
        }

        /// <summary>
        /// Get a list of apps accessible by a user, not including personal apps.
        /// https://developers.onelogin.com/api-docs/1/users/get-apps-for-user
        /// </summary>
        /// <param name="userId">Set to the id of the user that you want to return.</param>
        /// <returns></returns>
        public async Task<GetAppsForUserResponse> GetAppsForUser(int userId)
        {
            return await GetResource<GetAppsForUserResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/apps");

        }

        /// <summary>
        /// Get a list of role IDs that have been assigned to a user.
        /// </summary>
        /// <param name="userId">Set to the id of the user for which you want to return a list of assigned roles.</param>
        /// <returns></returns>
        public async Task<GetRolesForUser> GetRolesForUser(int userId)
        {
            return await GetResource<GetRolesForUser>($"{Endpoints.ONELOGIN_USERS}/{userId}/roles");
        }

        /// <summary>
        /// Returns a list of all custom attribute fields (also known as custom user fields) that have been defined for your account.
        /// </summary>
        /// <returns></returns>
        public async Task<GetCustomAttributesResponse> GetCustomAttributes()
        {
            return await GetResource<GetCustomAttributesResponse>($"{Endpoints.ONELOGIN_USERS}/custom_attributes");
        }


        /// <summary>
        /// Creates a onelogin user account.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns></returns>
        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            return await PostResource<CreateUserResponse>(Endpoints.ONELOGIN_USERS, request);
        }


        /// <summary>
        /// Updates a onelogin user account.
        /// </summary>
        /// <param name="userId">Set to the id of the user which you want to update.</param>
        /// <param name="byIdRequest">The request object.</param>
        /// <returns></returns>
        public async Task<GetUsersResponse> UpdateUserById(int userId, UpdateUserByIdRequest byIdRequest)
        {
            return await PutResource<GetUsersResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}", byIdRequest);
        }

        /// <summary>
        /// Assign one or more existing roles to a user.
        /// </summary>
        /// <param name="userId">Set to the id of the user to which you want to assign a role. If you don’t know the user’s id, use the Get Users API call to return all users and their id values.</param>
        /// <param name="roleIds">An array of one or more role IDs. The IDs must be positive integers.</param>
        /// <returns></returns>
        public async Task<EmptyResponse> AssignRoleToUser(int userId, IEnumerable<int> roleIds)
        {
            var request = new AssignRoleToUserRequest { RoleIds = roleIds.ToList() };
            return await PutResource<EmptyResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/add_roles", request);
        }

        /// <summary>
        /// Remove one or more existing roles from a user. This API will not remove roles that were added to a user via mapping or provisioning.
        /// </summary>
        /// <param name="userId">Set to the id of the user for whom you want to remove a role. If you don’t know the user’s id, use the Get Users API call to return all users and their id values.</param>
        /// <param name="roleIds">An array of one or more role IDs. The IDs must be positive integers.</param>
        /// <returns></returns>
        public async Task<EmptyResponse> RemoveRoleFromUser(int userId, IEnumerable<int> roleIds)
        {
            var request = new RemoveRoleFromUserRequest { RoleIds = roleIds.ToList() };
            return await PutResource<EmptyResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/remove_roles", request);
        }

        /// <summary>
        /// Initially set or subsequently change a user’s password.
        /// Note that setting a user password using cleartext via this API is comparable to using our in-browser, form-based Change Password functionality on top of an encrypted channel.
        /// Note also that when you set a password via this API, the password change must comply with your third-party user directory’s password policy for the user.
        /// </summary>
        /// <param name="userId">Set to the id of the user for which you want to set or reset a password. If you don’t know the user’s id, use the Get Users API call to return all users and their  id values.</param>
        /// <param name="password">Set to the password value using cleartext.
        /// Hashes are never stored as cleartext. They are stored securely using cryptographic hash. OneLogin continuously upgrades the strength of the hash. Ensure that the value meets the password strength requirements set for the account.
        /// </param>
        /// <param name="validatePolicy">Defaults to false. This will validate the password against the users OneLogin password policy.</param>
        /// <returns></returns>
        public async Task<EmptyResponse> SetPasswordByIdUsingCleartext(int userId, string password, bool validatePolicy = false)
        {
            var request = new SetPasswordByIdUsingCleartextRequest { Password = password, PasswordConfirmation = password, ValidatePolicy = validatePolicy };
            return await PutResource<EmptyResponse>($"{Endpoints.ONELOGIN_USERS}/set_password_clear_text/{userId}", request);
        }

        /// <summary>
        /// Initially set or subsequently change a user’s password.
        /// Note that this API cannot verify that the password value supplied meets the password complexity requirements set for the user’s account.If this is a concern, and you use a third-party directory like AD or LDAP, you can use the cleartext version of this API, which can update the password in a third-party directory directly, and enforces the password complexity requirements of the third-party directory.
        /// </summary>
        /// <param name="userId">Set to the id of the user for which you want to set or reset a password. If you don’t know the user’s id, use the Get Users API call to return all users and their  id values.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<EmptyResponse> SetPasswordByIdUsingSaltAndSHA256(int userId, SetPasswordByIdUsingSaltAndSHA256 request)
        {
            return await PutResource<EmptyResponse>($"{Endpoints.ONELOGIN_USERS}/set_password_using_salt/{userId}", request);
        }

        /// <summary>
        /// Set a custom attribute field (also known as a custom user field) value for a user.
        /// The custom attribute field must exist for your account.For details about defining custom user fields in OneLogin, see Custom User Fields.
        /// </summary>
        /// <param name="userId">Set to the id of the user for whom you want to set custom attribute values. If you don’t know the user’s id, use the Get Users API call to return all users and their id values.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<EmptyResponse> SetCustomAttributeValue(int userId, SetCustomAttributeRequest request)
        {
            return await PutResource<EmptyResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/set_custom_attributes", request);
        }

        /// <summary>
        /// Set the State for a user.
        /// States describe a stage in a process(such as user account approval). User state determines the possible statuses a user account can be in.
        /// </summary>
        /// <param name="userId">Set to the id of the user whose state you want to update. </param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<EmptyResponse> SetUserState(int userId, SetUserStateRequest request)
        {
            return await PutResource<EmptyResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/set_state", request);
        }

        /// <summary>
        /// Log a user out of any and all sessions.
        /// </summary>
        /// <param name="userId">Set to the id of the user that you want to log out. </param>
        /// <returns></returns>
        public async Task<EmptyResponse> LogUserOut(int userId)
        {
            return await PutResource<EmptyResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/logout", new {});
        }

        /// <summary>
        /// Log a user out of any and all sessions.
        /// </summary>
        /// <param name="userId">Set to the id of the user that you want to log out. </param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<EmptyResponse> LockUserAccount(int userId, LockUserAccountRequest request)
        {
            return await PutResource<EmptyResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/lock_user", request);
        }

        /// <summary>
        /// Use this call to delete a user by ID.
        /// </summary>
        /// <param name="userId">Set to the id of the user that you want to log out. </param>
        /// <returns></returns>
        public async Task<EmptyResponse> DeleteUserById(int userId)
        {
            return await DeleteResource<EmptyResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}");
        }
    }
}
