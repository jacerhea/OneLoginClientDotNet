using System.Runtime.Serialization;
using OneLogin.Descriptors;

namespace OneLogin.Requests
{
    /// <summary>
    /// Set of fields to be sent when creating a user.
    /// </summary>
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/create-user")]
    [DataContract]
    public class CreateUserRequest
    {
        /// <summary>
        /// User’s email address, which he also uses to log in to OneLogin.
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// If the user’s directory is set to authenticate using a user name value, this is the value used to sign in.
        /// </summary>
        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// User’s first name.
        /// </summary>
        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "company")]
        public string Company { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "department")]
        public string Department { get; set; }

        /// <summary>
        /// Group to which the user belongs.
        /// </summary>
        [DataMember(Name = "group_id")]
        public int? GroupId { get; set; }

        /// <summary>
        /// Number of sequential invalid login attempts the user has made that is less than or equal to the Maximum invalid login attempts value defined on the Session page in OneLogin.
        /// When this number reaches this value, the user account will be locked for the amount of time defined by the Lock effective period field on the Session page and this value will be reset to 0.
        /// </summary>
        [DataMember(Name = "invalid_login_attempts")]
        public int? InvalidLoginAttempts { get; set; }

        /// <summary>
        /// User’s last name.
        /// </summary>
        [DataMember(Name = "lastname")]
        public string LastName { get; set; }

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
        /// User’s phone number.
        /// </summary>
        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Synchronized from Active Directory.
        /// </summary>
        [DataMember(Name = "distinguished_name")]
        public string DistinguishedName { get; set; }

        /// <summary>
        /// External ID that can be used to uniquely identify the user in another system.
        /// </summary>
        [DataMember(Name = "external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// ID of the directory (Active Directory, LDAP, for example) from which the user was created.
        /// </summary>
        [DataMember(Name = "directory_id")]
        public int? DirectoryId { get; set; }

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

    }
}
