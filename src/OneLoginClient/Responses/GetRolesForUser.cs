using System.Collections.Generic;
using OneLogin.Descriptors;

namespace OneLogin.Responses
{
    /// <summary>
    /// A list of role IDs that have been assigned to a user.
    /// </summary>
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-roles-for-user")]
    public class GetRolesForUser : BaseResponse<List<int>>
    {
    }
}
