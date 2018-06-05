using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Remove one or more existing roles from a user.
    /// </summary>
    [DataContract]
    public class RemoveRoleFromUserRequest
    {
        /// <summary>
        /// Set to an array of one or more role IDs. The IDs must be positive integers.
        /// </summary>
        [DataMember(Name = "role_id_array")]
        public List<int> RoleIds { get; set; }
    }
}
