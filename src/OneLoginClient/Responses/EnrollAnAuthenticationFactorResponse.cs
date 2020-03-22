using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// If the authentication factor requires confirmation to complete, then the device will have an active state of false otherwise it will have an active state of true (corresponding to devices that are either pending confirmation or not)
    /// </summary>
    [DataContract]
    public class EnrollAnAuthenticationFactorResponse : BaseResponse<AuthenticationFactor>
    {

    }


    /// <summary>
    /// OneLogin provides a series of API endpoints that let you manage MFA for your users. You can enroll multi-factor devices, trigger the sending of One-Time Password (OTP) codes via SMS or Push notification and, Verify codes to authenticate users.
    /// </summary>
    [DataContract]
    public class AuthenticationFactor{

        /// <summary>
        /// True = enabled (used successfully for authentication at least once). False = pending (registered but never used).
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [DataMember(Name = "active")]
        public bool Active { get; set; }

        /// <summary>
        /// True = is user’s default MFA device for OneLogin.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        [DataMember(Name = "default")]
        public bool Default { get; set; }

        /// <summary>
        /// A short lived token that is required to Verify the Factor. This token expires in 120 seconds
        /// </summary>
        /// <value>The state token.</value>
        [DataMember(Name = "state_token")]
        public string StateToken { get; set; }

        /// <summary>
        /// "Official" authentication factor name, as it appears to administrators in OneLogin.
        /// </summary>
        /// <value>The name of the auth factor.</value>
        [DataMember(Name = "auth_factor_name")]
        public string AuthFactorName { get; set; }

        /// <summary>
        /// For OTP codes sent via SMS, the phone number receiving the SMS message.
        /// </summary>
        /// <value>The phone number.</value>
        [DataMember(Name = "phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Authentication factor display name as it appears to users upon initial registration, as defined by admins at Settings > Authentication Factors.
        /// </summary>
        /// <value>The name of the type display.</value>
        [DataMember(Name = "type_display_name")]
        public string TypeDisplayName { get; set; }

        /// <summary>
        /// true: You MUST Activate this Factor to trigger an SMS or Push notification before Verifying the OTP code.
        /// false: No Activation required.You can Verify the OTP immediately.
        /// MFA factors that provide both push notifications (user accepts notification) and pull code submission(user initiates code submission from device or enters it manually) should appear twice; once with needs_trigger: true and once with needs_trigger: false.
        /// </summary>
        /// <value><c>true</c> if needs trigger; otherwise, <c>false</c>.</value>
        [DataMember(Name = "needs_trigger")]
        public bool NeedsTrigger { get; set; }

        /// <summary>
        /// Authentication factor display name assigned by users when they enroll the device.
        /// </summary>
        /// <value>The name of the user display.</value>
        [DataMember(Name = "user_display_name")]
        public string UserDisplayName { get; set; }

        /// <summary>
        /// MFA device identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        public long Id { get; set; }
    }
}
