using OneLogin.Descriptors;

namespace OneLogin.Responses
{
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-apps-for-user")]
    public class GetAppsResponse : BaseResponse<UserApps>
    {

    }

    public class UserApps
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string provisioned { get; set; }
        public bool extension { get; set; }
        public int login_id { get; set; }
        public bool personal { get; set; }
    }
}
