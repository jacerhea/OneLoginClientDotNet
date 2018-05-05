namespace OneLogin
{
    public static class Endpoints
    {
        public const string OneLoginApiBase = "https://api.<us_or_eu>.onelogin.com/";
        public const string Token = OneLoginApiBase + "auth/oauth2/token/";
        public const string API = "api/";
        public const string ApiVersion = "1/";
        public const string BaseApi = OneLoginApiBase + API + ApiVersion;
        public const string ONELOGIN_USERS = "users";
        public const string ONELOGIN_GROUPS = "groups";
        public const string ONELOGIN_EVENTS = "events";
        public const string ONELOGIN_INVITES = "invites";
        public const string ONELOGIN_ROLES = "roles";
    }
}
