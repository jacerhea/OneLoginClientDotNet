using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    [DataContract]
    public class GetRoleResponse : BaseResponse<Role>
    {
    }

    [DataContract]
    public class GetRolesResponse : PaginationBaseResponse<Role>
    {
    }


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
