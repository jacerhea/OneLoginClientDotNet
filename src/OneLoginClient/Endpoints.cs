namespace OneLogin
{
    /// <summary>
    /// Set of OneLogin Resource endpoints.
    /// </summary>
    public static class Endpoints
    {
        public const string OneLoginApiBase = "https://api.<us_or_eu>.onelogin.com/";
        /// <summary>
        /// https://api.<region>.onelogin.com/auth/oauth2/v2/token
        /// </summary>
        public const string Token = OneLoginApiBase + "auth/oauth2/token/";
        public const string API = "api/";
        public const string ApiVersion = "1/";
        public const string BaseApi = OneLoginApiBase + API + ApiVersion;

        /// <summary>
        /// https://api.<us_or_eu>.onelogin.com/api/1/users
        /// </summary>
        public const string ONELOGIN_USERS = "users";

        /// <summary>
        /// https://api.<us_or_eu>.onelogin.com/api/1/groups
        /// </summary>
        public const string ONELOGIN_GROUPS = "groups";

        /// <summary>
        /// https://api.<us_or_eu>.onelogin.com/api/1/events/types
        /// </summary>
        public const string ONELOGIN_EVENTS = "events";

        /// <summary>
        /// https://api.<us_or_eu>.onelogin.com/api/1/invites/get_invite_link
        /// </summary>
        public const string ONELOGIN_INVITES = "invites";

        /// <summary>
        /// https://api.<us_or_eu>.onelogin.com/api/1/roles
        /// </summary>
        public const string ONELOGIN_ROLES = "roles";
    }
}
