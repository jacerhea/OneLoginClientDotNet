using System;
using System.Collections.Generic;
using System.Text;
using OneLogin.Descriptors;

namespace OneLogin.Requests
{
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/create-user")]
    public class CreateUserRequest
    {
        public string email { get; set; }
        public string username { get; set; }
        public string title { get; set; }
        public string firstname { get; set; }
        public string company { get; set; }
        public string department { get; set; }
        public string group_id { get; set; }
        public int? invalid_login_attempts { get; set; }
        public string lastname { get; set; }
        public string notes { get; set; }
        public string openid_name { get; set; }
        public string locale_code { get; set; }
        public string phone { get; set; }
        public string distinguished_name { get; set; }
        public string external_id { get; set; }
        public string directory_id { get; set; }
        public string member_of { get; set; }
        public string samaccountname { get; set; }
        public string userprincipalname { get; set; }
        public string manager_ad_id { get; set; }
    }
}
