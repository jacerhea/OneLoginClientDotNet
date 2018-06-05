using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    [DataContract]
    public class GetGroupsResponse : PaginationBaseResponse<Group>
    {
    }

    /// <summary>
    /// Think of groups as departments. Groups enable you to split your user base into smaller pieces that can be more easily managed.
    /// </summary>
    [DataContract]
    public class Group
    {
        /// <summary>
        /// Group’s unique ID in OneLogin.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Group name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Deprecated. Will always display the attribute null.
        /// </summary>
        [DataMember(Name = "reference")]
        public string Reference { get; set; }
    }
}
