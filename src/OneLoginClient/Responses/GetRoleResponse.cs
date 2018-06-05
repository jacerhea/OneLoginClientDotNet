using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// Response message the requested role.
    /// </summary>
    [DataContract]
    public class GetRoleResponse : BaseResponse<Role>
    {
    }

    /// <summary>
    /// Response message containing the set of requested roles.
    /// </summary>
    [DataContract]
    public class GetRolesResponse : PaginationBaseResponse<Role>
    {
    }


    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Role
    {
        /// <summary>
        /// Role’s unique ID in OneLogin.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Role name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
