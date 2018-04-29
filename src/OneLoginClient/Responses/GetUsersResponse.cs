using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OneLogin.Descriptors;
using OneLogin.Types;

namespace OneLogin.Responses
{
    /// <summary>
    /// This call returns up to 50 users per page.
    /// For details about using the pagination element to easily “page” through users, see <a href="https://developers.onelogin.com/api-docs/1/getting-started/using-query-parameters#pagination">Pagination</a>.
    /// For details about each element in the User resource, see <a href="https://developers.onelogin.com/api-docs/1/users/user-resource">User Resource</a>.
    /// </summary>
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-users")]
    public class GetUsersResponse : PaginationBaseResponse<User>
    {

    }


    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/user-resource")]
    public class User
    {
        /// <summary>
        /// Date and time at which the user’s status was set to 1 (active).
        /// </summary>
        public DateTime? activated_at { get; set; }

        /// <summary>
        /// Date and time at which the user was created.
        /// </summary>
        public DateTime created_at { get; set; }

        /// <summary>
        /// User’s email address, which he also uses to log in to OneLogin.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// If the user’s directory is set to authenticate using a user name value, this is the value used to sign in.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// User’s first name.
        /// </summary>
        public string firstname { get; set; }

        /// <summary>
        /// Group to which the user belongs.
        /// </summary>
        public int? group_id { get; set; }

        /// <summary>
        /// User’s unique ID in OneLogin.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Number of sequential invalid login attempts the user has made that is less than or equal to the Maximum invalid login attempts value defined on the Session page in OneLogin.
        /// When this number reaches this value, the user account will be locked for the amount of time defined by the Lock effective period field on the Session page and this value will be reset to 0.
        /// </summary>
        public int? invalid_login_attempts { get; set; }

        /// <summary>
        /// Date and time at which an invitation to OneLogin was sent to the user.
        /// </summary>
        public DateTime? invitation_sent_at { get; set; }

        /// <summary>
        /// Date and time of the user’s last login.
        /// </summary>
        public DateTime? last_login { get; set; }

        /// <summary>
        /// User’s last name.
        /// </summary>
        public string lastname { get; set; }

        /// <summary>
        /// Date and time at which the user’s account will be unlocked.
        /// </summary>
        public string locked_until { get; set; }

        /// <summary>
        /// Notes entered about the user.
        /// </summary>
        public string comment { get; set; }

        /// <summary>
        /// OpenID URL that can be configured in other applications that accept OpenID for sign-in.
        /// </summary>
        public string openid_name { get; set; }

        /// <summary>
        /// Represents a geographical, political, or cultural region. Some features may use the locale value to tailor the display of information, such as numbers, for the user based on locale-specific customs and conventions.
        /// </summary>
        public string locale_code { get; set; }

        /// <summary>
        /// Date and time at which the user’s password was last changed.
        /// </summary>
        public DateTime? password_changed_at { get; set; }

        /// <summary>
        /// User’s phone number.
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Determines the user’s ability to log in to OneLogin.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusType status { get; set; }


        /// <summary>
        /// Date and time at which the user’s information was last updated.
        /// </summary>
        public DateTime updated_at { get; set; }
        public string distinguished_name { get; set; }
        public string external_id { get; set; }
        public string directory_id { get; set; }

        /// <summary>
        /// Synchronized from Active Directory.
        /// </summary>
        public string member_of { get; set; }

        /// <summary>
        /// Synchronized from Active Directory.
        /// </summary>
        public string samaccountname { get; set; }

        /// <summary>
        /// Synchronized from Active Directory.
        /// </summary>
        public string userprincipalname { get; set; }

        /// <summary>
        /// ID of the user’s manager in Active Directory.
        /// </summary>
        public string manager_ad_id { get; set; }

        /// <summary>
        /// Role IDs to which the user is assigned.
        /// </summary>
        public List<int> role_id { get; set; }
        public string company { get; set; }
        public string department { get; set; }
        public string title { get; set; }

        /// <summary>
        /// Represents the user’s stage in a process (such as user account approval). User state determines the possible statuses a user account can be in.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public State state { get; set; }


        public string trusted_idp_id { get; set; }
        public CustomAttributes custom_attributes { get; set; }
    }

    public class CustomAttributes
    {
        public string alias { get; set; }
        public string branch { get; set; }
    }
}
