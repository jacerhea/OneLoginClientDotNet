using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// An array of Event objects is sent to your registered endpoint as a POST request.
    /// </summary>
    [DataContract]
    public class WebhookResponse
    {
        public string error_description { get; set; }
        public string login_name { get; set; }
        public string app_name { get; set; }
        public string authentication_factor_description { get; set; }
        public string certificate_name { get; set; }
        public string certificate_id { get; set; }
        public string event_timestamp { get; set; }
        public string assumed_by_superadmin_or_reseller { get; set; }
        public string directory_name { get; set; }
        public int actor_user_id { get; set; }
        public string user_name { get; set; }
        public string mapping_id { get; set; }
        public string radius_config_id { get; set; }
        public string risk_score { get; set; }
        public string otp_device_id { get; set; }
        public string imported_user_id { get; set; }
        public string resolution { get; set; }
        public string directory_id { get; set; }
        public string authentication_factor_id { get; set; }
        public string param { get; set; }
        public string risk_cookie_id { get; set; }
        public string app_id { get; set; }
        public string custom_message { get; set; }
        public string browser_fingerprint { get; set; }
        public string actor_system { get; set; }
        public string uuid { get; set; }
        public string otp_device_name { get; set; }
        public string actor_user_name { get; set; }
        public string user_field_name { get; set; }
        public string assuming_acting_user_id { get; set; }
        public string adc_id { get; set; }
        public string solved { get; set; }
        public string api_credential_name { get; set; }
        public string imported_user_name { get; set; }
        public string note_title { get; set; }
        public string trusted_idp_name { get; set; }
        public string policy_id { get; set; }
        public string role_name { get; set; }
        public string service_directory_id { get; set; }
        public string object_id { get; set; }
        public int account_id { get; set; }
        public string user_field_id { get; set; }
        public string resolved_by_user_id { get; set; }
        public string group_id { get; set; }
        public string client_id { get; set; }
        public string ipaddr { get; set; }
        public string login_id { get; set; }
        public string notes { get; set; }
        public int event_type_id { get; set; }
        public int user_id { get; set; }
        public string risk_reasons { get; set; }
        public string proxy_agent_name { get; set; }
        public string policy_type { get; set; }
        public string role_id { get; set; }
        public string user_agent { get; set; }
        public string privilege_name { get; set; }
        public string group_name { get; set; }
        public string entity { get; set; }
        public string resource_type_id { get; set; }
        public string resolved_at { get; set; }
        public string note_id { get; set; }
        public string mapping_name { get; set; }
        public string task_name { get; set; }
        public string authentication_factor_type { get; set; }
        public string proxy_agent_id { get; set; }
        public string adc_name { get; set; }
        public string radius_config_name { get; set; }
        public string policy_name { get; set; }
        public string trusted_idp_id { get; set; }
        public string privilege_id { get; set; }
        public string proxy_ip { get; set; }
        public string directory_sync_run_id { get; set; }
    }
}
