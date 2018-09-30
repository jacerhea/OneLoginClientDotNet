using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// Returns a list of all custom attribute fields (also known as custom user fields) that have been defined for your account.
    /// https://developers.onelogin.com/api-docs/1/users/get-custom-attributes
    /// </summary>
    [DataContract]
    public class GetCustomAttributesResponse : BaseResponse<List<string>>
    {
    }
}
