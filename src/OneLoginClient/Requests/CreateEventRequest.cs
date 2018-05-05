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
        public int actor_system { get; set; }

        [DataMember(Name = "actor_user_id")]
        public string actor_user_id { get; set; }

        [DataMember(Name = "app_id")]
        public string app_id { get; set; }

        [DataMember(Name = "assuming_acting_user_id")]
        public string assuming_acting_user_id { get; set; }

        [DataMember(Name = "custom_message")]
        public string custom_message { get; set; }

        [DataMember(Name = "directory_sync_run_id")]
        public string directory_sync_run_id { get; set; }

        [DataMember(Name = "group_id")]
        public string group_id { get; set; }

        [DataMember(Name = "group_name")]
        public string group_name { get; set; }

        [DataMember(Name = "ipaddr")]
        public string ipaddr { get; set; }

        [DataMember(Name = "otp_device_id")]
        public string otp_device_id { get; set; }

        [DataMember(Name = "otp_device_name")]
        public string otp_device_name { get; set; }

        [DataMember(Name = "policy_id")]
        public string policy_id { get; set; }

        [DataMember(Name = "policy_name")]
        public string policy_name { get; set; }

        [DataMember(Name = "role_id")]
        public string role_id { get; set; }

        [DataMember(Name = "role_name")]
        public string role_name { get; set; }

        [DataMember(Name = "user_id")]
        public string user_id { get; set; }

        [DataMember(Name = "user_name")]
        public string user_name { get; set; }
    }
}
