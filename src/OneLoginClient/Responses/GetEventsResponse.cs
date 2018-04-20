using System;

namespace OneLogin.Responses
{
    public class GetEventsResponse : PaginationBaseResponse<Event>
    {
    }

    public class Event
    {
        public long id { get; set; }
        public DateTime created_at { get; set; }
        public int account_id { get; set; }
        public int? user_id { get; set; }
        public int event_type_id { get; set; }
        public object notes { get; set; }
        public string ipaddr { get; set; }
        public int? actor_user_id { get; set; }
        public int? assuming_acting_user_id { get; set; }
        public int? role_id { get; set; }
        public int? app_id { get; set; }
        public string group_id { get; set; }
        public string otp_device_id { get; set; }
        public string policy_id { get; set; }
        public string actor_system { get; set; }
        public string custom_message { get; set; }
        public string role_name { get; set; }
        public string app_name { get; set; }
        public string group_name { get; set; }
        public string actor_user_name { get; set; }
        public string user_name { get; set; }
        public string policy_name { get; set; }
        public string otp_device_name { get; set; }
        public string operation_name { get; set; }
        public string directory_sync_run_id { get; set; }
        public string directory_id { get; set; }
        public string resolution { get; set; }
        public string client_id { get; set; }
        public string resource_type_id { get; set; }
        public string error_description { get; set; }
        public string proxy_ip { get; set; }
    }
}
