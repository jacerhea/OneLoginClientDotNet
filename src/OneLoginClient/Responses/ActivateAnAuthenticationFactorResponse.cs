using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// Use this API to trigger an SMS or Push notification containing a One-Time Password (OTP) that can be used to authenticate a user with the Verify Factor call.  It is only necessary to activate a factor if needs_trigger is returned as true via the Enroll Factor or Get Enrolled Factors calls.
    /// </summary>
    public class ActivateAnAuthenticationFactorResponse : BaseResponse<ActivatedFactor>
    {
    }

    /// <summary>
    /// OneLogin provides a series of API endpoints that let you manage MFA for your users. You can enroll multi-factor devices, trigger the sending of One-Time Password (OTP) codes via SMS or Push notification and, Verify codes to authenticate users.
    /// </summary>
    [DataContract]
    public class ActivatedFactor
    {

        /// <summary>
        /// Authentication factor display name assigned by users when they register the device.
        /// </summary>
        [DataMember(Name = "user_display_name")]
        public string UserDisplayName { get; set; }

        /// <summary>
        /// true = enabled (used successfully for authentication at least once). false = pending (registered but never used).
        /// </summary>
        [DataMember(Name = "active")]

        public bool Active { get; set; }

        /// <summary>
        /// A short lived token that is required to Verify the Factor. This token expires in 120 seconds.
        /// </summary>
        [DataMember(Name = "state_token")]
        public string StateToken { get; set; }

        /// <summary>
        /// "Official" authentication factor name, as it appears to administrators in OneLogin.
        /// </summary>
        [DataMember(Name = "auth_factor_name")]
        public string AuthFactorName { get; set; }

        /// <summary>
        /// Authentication factor display name as it appears to users upon initial registration, as defined by admins at Settings > Authentication Factors.
        /// </summary>
        [DataMember(Name = "type_display_name")]
        public string TypeDisplayName { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// MFA device identifier.
        /// </summary>
        [DataMember(Name = "device_id")]
        public int DeviceId { get; set; }
    }
}
