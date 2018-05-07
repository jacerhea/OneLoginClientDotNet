using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Use this API to generate a session login token in scenarios in which MFA may or may not be required. Both scenarios are supported. A session login token expires two minutes after creation.
    /// </summary>
    [DataContract]
    public class CreateSessionLoginToken
    {
        /// <summary>
        /// Set to the username or email of the user that you want to log in.
        /// </summary>
        [DataMember(Name = "username_or_email")]
        public string UsernameOrEmail { get; set; }

        /// <summary>
        /// Set to the password of the user that you want to log in.
        /// </summary>
        [DataMember(Name = "password")]
        public string password { get; set; }

        /// <summary>
        /// Set to the subdomain of the user that you want to log in.
        /// For example, if your OneLogin URL is splinkly.onelogin.com, enter splinkly as the subdomain value.
    /// </summary>
        [DataMember(Name = "subdomain")]
        public string subdomain { get; set; }

        [DataMember(Name = "return_to_url")]
        public string return_to_url { get; set; }

        [DataMember(Name = "ip_address")]
        public string ip_address { get; set; }

        [DataMember(Name = "browser_id")]
        public string browser_id { get; set; }
    }
}
