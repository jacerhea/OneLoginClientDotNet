using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    [DataContract]
    public class GetEnrolledAuthenticationFactorResponse : BaseStatusResponse
    {
        [DataMember(Name = "data")]
        public EnrolledAuthenticationFactorContainer Data { get; set; }
    }

    [DataContract]
    public class EnrolledAuthenticationFactorContainer
    {
        [DataMember(Name = "otp_devices")]
        public List<OtpDevice> OTP_Devices { get; set; }
    }

    [DataContract]
    public class OtpDevice
    {
        /// <summary>
        /// Authentication factor display name as it appears to users upon initial registration, as defined by admins at Settings > Authentication Factors.
        /// </summary>
        /// <value>The name of the type display.</value>
        [DataMember(Name = "type_display_name")]
        public string TypeDisplayName { get; set; }

        /// <summary>
        /// true = enabled (used successfully for authentication at least once). false = pending (registered but never used).
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [DataMember(Name ="active")]
        public bool Active { get; set; }

        /// <summary>
        /// Authentication factor display name assigned by users when they register the device.
        /// </summary>
        /// <value>The name of the user display.</value>
        [DataMember(Name ="user_display_name")]
        public string UserDisplayName { get; set; }

        [DataMember(Name = "default")]
        public bool Default { get; set; }

        /// <summary>
        /// For OTP codes sent via SMS, the phone number receiving the SMS message.
        /// </summary>
        /// <value>The phone number.</value>
        [DataMember(Name ="phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// "Official" authentication factor name, as it appears to administrators in OneLogin.
        /// </summary>
        /// <value>The name of the auth factor.</value>
        [DataMember(Name ="auth_factor_name")]
        public string AuthFactorName { get; set; }

        /// <summary>
        /// MFA device identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember(Name ="id")]
        public int Id { get; set; }

        /// <summary>
        /// true: You MUST Activate this Factor to trigger an SMS or Push notification before Verifying the OTP code.
        /// false: No Activation required.You can Verify the OTP immediately.
        /// MFA factors that provide both push notifications (user accepts notification) and pull code submission(user initiates code submission from device or enters it manually) should appear twice; once with needs_trigger: true and once with needs_trigger: false.
        /// </summary>
        /// <value><c>true</c> if needs trigger; otherwise, <c>false</c>.</value>
        [DataMember(Name = "needs_trigger")]
        public bool NeedsTrigger { get; set; }
    }
}
