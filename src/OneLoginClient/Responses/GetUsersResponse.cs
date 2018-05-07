using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OneLogin.Types;

namespace OneLogin.Responses
{
    /// <summary>
    /// This call returns up to 50 users per page.
    /// For details about using the pagination element to easily “page” through users, see <a href="https://developers.onelogin.com/api-docs/1/getting-started/using-query-parameters#pagination">Pagination</a>.
    /// For details about each element in the User resource, see <a href="https://developers.onelogin.com/api-docs/1/users/user-resource">User Resource</a>.
    /// </summary>
    /// <inheritdoc cref="OneLogin.Responses.PaginationBaseResponse{T}" />
    public class GetUsersResponse : PaginationBaseResponse<User>
    {

    }

    /// <summary>
    /// A user of the Onelogin platform.
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// Date and time at which the user’s status was set to 1 (active).
        /// </summary>
        [DataMember(Name = "activated_at")]
        public DateTime? ActivatedAt { get; set; }

        /// <summary>
        /// Date and time at which the user was created.
        /// </summary>
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// User’s email address, which he also uses to log in to OneLogin.
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// If the user’s directory is set to authenticate using a user name value, this is the value used to sign in.
        /// </summary>
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        /// <summary>
        /// User’s first name.
        /// </summary>
        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// Group to which the user belongs.
        /// </summary>
        [DataMember(Name = "group_id")]
        public int? GroupId { get; set; }

        /// <summary>
        /// User’s unique ID in OneLogin.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Number of sequential invalid login attempts the user has made that is less than or equal to the Maximum invalid login attempts value defined on the Session page in OneLogin.
        /// When this number reaches this value, the user account will be locked for the amount of time defined by the Lock effective period field on the Session page and this value will be reset to 0.
        /// </summary>
        [DataMember(Name = "invalid_login_attempts")]
        public int? InvalidLoginAttempts { get; set; }

        /// <summary>
        /// Date and time at which an invitation to OneLogin was sent to the user.
        /// </summary>
        [DataMember(Name = "invitation_sent_at")]
        public DateTime? InvitationSentAt { get; set; }

        /// <summary>
        /// Date and time of the user’s last login.
        /// </summary>
        [DataMember(Name = "last_login")]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// User’s last name.
        /// </summary>
        [DataMember(Name = "lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// Date and time at which the user’s account will be unlocked.
        /// </summary>
        [DataMember(Name = "locked_until")]
        public string LockedUntil { get; set; }

        /// <summary>
        /// Notes entered about the user.
        /// </summary>
        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        /// <summary>
        /// OpenID URL that can be configured in other applications that accept OpenID for sign-in.
        /// </summary>
        [DataMember(Name = "openid_name")]
        public string OpenIdName { get; set; }

        /// <summary>
        /// Represents a geographical, political, or cultural region. Some features may use the locale value to tailor the display of information, such as numbers, for the user based on locale-specific customs and conventions.
        /// </summary>
        [DataMember(Name = "locale_code")]
        public string LocaleCode { get; set; }

        /// <summary>
        /// Date and time at which the user’s password was last changed.
        /// </summary>
        [DataMember(Name = "password_changed_at")]
        public DateTime? PasswordChangedAt { get; set; }

        /// <summary>
        /// User’s phone number.
        /// </summary>
        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Determines the user’s ability to log in to OneLogin.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "status")]
        public StatusType Status { get; set; }


        /// <summary>
        /// Date and time at which the user’s information was last updated.
        /// </summary>
        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "distinguished_name")]
        public string DistinguishedName { get; set; }

        [DataMember(Name = "external_id")]
        public string ExternalId { get; set; }

        [DataMember(Name = "directory_id")]
        public string DirectoryId { get; set; }

        /// <summary>
        /// Synchronized from Active Directory.
        /// </summary>
        [DataMember(Name = "member_of")]
        public string MemberOf { get; set; }

        /// <summary>
        /// Synchronized from Active Directory.
        /// </summary>
        [DataMember(Name = "samaccountname")]
        public string SamAccountName { get; set; }

        /// <summary>
        /// Synchronized from Active Directory.
        /// </summary>
        [DataMember(Name = "userprincipalname")]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// ID of the user’s manager in Active Directory.
        /// </summary>
        [DataMember(Name = "manager_ad_id")]
        public string ManagerAdId { get; set; }

        /// <summary>
        /// Role IDs to which the user is assigned.
        /// </summary>
        [DataMember(Name = "role_id")]
        public List<int> RoleId { get; set; }

        [DataMember(Name = "company")]
        public string Company { get; set; }

        [DataMember(Name = "department")]
        public string Department { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Represents the user’s stage in a process (such as user account approval). User state determines the possible statuses a user account can be in.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "state")]
        public State State { get; set; }


        [DataMember(Name = "trusted_idp_id")]
        public string TrustedIdpId { get; set; }


        /// <summary>
        /// Provides a list of custom attribute fields (also known as custom user fields) that are available for your account.
        /// The values returned correspond to the values you provided in the Shortname field when you defined the custom user field.
        /// </summary>
        [DataMember(Name = "custom_attributes")]
        public Dictionary<string, string> CustomAttributes { get; set; }
    }
  }
