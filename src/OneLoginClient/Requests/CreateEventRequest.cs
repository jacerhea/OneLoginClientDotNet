using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Create an event in the OneLogin event log.
    /// </summary>
    [DataContract]
    public class CreateEventRequest
    {
        /// <summary>
        /// Set to the ID of the event type you want to create. For a list of valid event type IDs, see Event Resource and Types.
        /// </summary>
        [DataMember(Name = "event_type_id")]
        public int EventTypeId { get; set; }

        /// <summary>
        /// Set to your account ID.
        /// </summary>
        [DataMember(Name = "account_id")]
        public int AccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "actor_system")]
        public int ActorSystem { get; set; }

        /// <summary>
        /// Value must exist in OneLogin.
        /// </summary>
        [DataMember(Name = "actor_user_id")]
        public string ActorUserId { get; set; }

        [DataMember(Name = "app_id")]
        public string AppId { get; set; }

        [DataMember(Name = "assuming_acting_user_id")]
        public string AssumingActingUserId { get; set; }

        [DataMember(Name = "custom_message")]
        public string CustomMessage { get; set; }

        [DataMember(Name = "directory_sync_run_id")]
        public string DirectorySyncRunId { get; set; }

        [DataMember(Name = "group_id")]
        public string GroupId { get; set; }

        [DataMember(Name = "group_name")]
        public string GroupName { get; set; }

        [DataMember(Name = "ipaddr")]
        public string IpAddress { get; set; }

        [DataMember(Name = "otp_device_id")]
        public string otp_device_id { get; set; }

        [DataMember(Name = "otp_device_name")]
        public string otp_device_name { get; set; }

        [DataMember(Name = "policy_id")]
        public string PolicyId { get; set; }

        [DataMember(Name = "policy_name")]
        public string PolicyName { get; set; }

        [DataMember(Name = "role_id")]
        public string RoleId { get; set; }

        [DataMember(Name = "role_name")]
        public string RoleName { get; set; }

        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [DataMember(Name = "user_name")]
        public string UserName { get; set; }
    }
}
