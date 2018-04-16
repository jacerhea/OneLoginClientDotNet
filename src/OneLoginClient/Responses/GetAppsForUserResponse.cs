using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OneLogin.Descriptors;
using OneLogin.Types;

namespace OneLogin.Responses
{
    /// <summary>
    /// Get a list of apps accessible by a user, not including personal apps.
    /// To get a list of apps accessible by a user to embed in your company intranet, for example, see Get Apps to Embed for a User.
    /// </summary>
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/get-apps-for-user")]
    public class GetAppsForUserResponse : BaseResponse<UserApps>
    {

    }

    [DataContract]
    public class UserApps
    {
        /// <summary>
        /// ID of the app that can be accessed by the user.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the application.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// URL to the app’s icon.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Indicates whether a username and password has been stored on the login for the app and user.
        /// </summary>
        [DataMember(Name = "provisioned")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProvisionedTypes? Provisioned { get; set; }

        /// <summary>
        /// Indicates whether the app requires the OneLogin browser extension to login.
        /// </summary>
        [DataMember(Name = "extension")]
        public bool Extension { get; set; }

        /// <summary>
        /// User’s ID in the app. For example, in one app the user’s ID may be  georgia.wong@company.com, but in another it may be georgia.wong.
        /// </summary>
        [DataMember(Name = "login_id")]
        public string LoginId { get; set; }

        /// <summary>
        /// Indicates whether the app is a user’s personal app.
        /// </summary>
        [DataMember(Name = "personal")]
        public bool Personal { get; set; }
    }
}