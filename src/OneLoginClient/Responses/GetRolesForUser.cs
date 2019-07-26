using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// A list of role IDs that have been assigned to a user.
    /// https://developers.onelogin.com/api-docs/1/users/get-roles-for-user
    /// </summary>
    [DataContract]
    public class GetRolesForUser : BaseResponse<List<int>>
    {
    }
}
