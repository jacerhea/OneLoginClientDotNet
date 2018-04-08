using System;
using System.Collections.Generic;
using OneLogin.Descriptors;

namespace OneLogin.Responses
{
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-users")]
    public class GetUsersResponse : BaseResponse<OneLoginUser>
    {

    }

    public class OneLoginUser
    {
        public DateTime activated_at { get; set; }
        public DateTime created_at { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public int group_id { get; set; }
        public int id { get; set; }
        public int invalid_login_attempts { get; set; }
        public DateTime invitation_sent_at { get; set; }
        public DateTime last_login { get; set; }
        public string lastname { get; set; }
        public object locked_until { get; set; }
        public object notes { get; set; }
        public string openid_name { get; set; }
        public object locale_code { get; set; }
        public DateTime password_changed_at { get; set; }
        public string phone { get; set; }
        public int status { get; set; }
        public DateTime updated_at { get; set; }
        public string distinguished_name { get; set; }
        public string external_id { get; set; }
        public string directory_id { get; set; }
        public string member_of { get; set; }
        public string samaccountname { get; set; }
        public object userprincipalname { get; set; }
        public object manager_ad_id { get; set; }
        public List<int> role_id { get; set; }
        public string company { get; set; }
        public string department { get; set; }
        public string title { get; set; }
        public int state { get; set; }
        public string trusted_idp_id { get; set; }
        public CustomAttributes custom_attributes { get; set; }
    }

    public class CustomAttributes
    {
        public string alias { get; set; }
        public string branch { get; set; }
    }
}
