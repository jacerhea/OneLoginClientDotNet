using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Request to authenticate a one-time password (OTP) code provided by a multifactor authentication (MFA) device.
    /// If this is the first time that the OTP device has been confirmed, then the device will be updated to have a state of enabled.
    /// </summary>
    [DataContract]
    public class UpdateUserByIdRequest
    {
    }
}
