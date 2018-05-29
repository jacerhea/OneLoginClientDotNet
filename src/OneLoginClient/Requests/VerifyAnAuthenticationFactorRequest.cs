using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Request to authenticate a one-time password (OTP) code provided by a multifactor authentication (MFA) device.
    /// If this is the first time that the OTP device has been confirmed, then the device will be updated to have a state of enabled.
    /// </summary>
    [DataContract]
    public class VerifyAnAuthenticationFactorRequest
    {
        /// <summary>
        /// The state_token is returned after a successful request to Enroll a Factor or Activate a Factor.
        /// </summary>
        [DataMember(Name = "state_token")]
        public string StateToken { get; set; }

        /// <summary>
        /// OTP code provided by the device or SMS message sent to user.
        /// </summary>
        [DataMember(Name = "otp_token")]
        public string OtpToken { get; set; }
    }
}
