using System;
using System.Collections.Generic;
using OneLogin.Descriptors;

namespace OneLogin.Requests
{
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-users")]
    public class GetUsersRequest
    {
        public int directory_id { get; set; }

        public string email { get; set; }

        public string external_id { get; set; }

        public string firstname { get; set; }

        public long id { get; set; }

        public string manager_ad_id { get; set; }

        public List<int> role_id { get; set; }

        public string samaccountname { get; set; }

        public DateTimeOffset? since { get; set; }

        public DateTimeOffset? until { get; set; }

        public string username { get; set; }

        public string userprincipalname { get; set; }
    }
}
