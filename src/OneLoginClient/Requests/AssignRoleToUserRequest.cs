using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Assign one or more existing roles to a user.
    /// </summary>
    [DataContract]
    public class AssignRoleToUserRequest
    {
        /// <summary>
        /// Set to an array of one or more role IDs. The IDs must be positive integers.
        /// </summary>
        [DataMember(Name = "role_id_array")]
        public List<int> RoleIds { get; set; }
    }
}
