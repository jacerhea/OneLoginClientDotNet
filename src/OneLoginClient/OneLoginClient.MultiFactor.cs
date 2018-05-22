using System.Threading.Tasks;
using OneLogin.Requests;
using OneLogin.Responses;

namespace OneLogin
{
    public partial class OneLoginClient
    {
        /// <summary>
        /// Use this API to return a list of authentication factors that are available for user enrollment via API.
        /// </summary>
        /// <param name="userId">Set to the id of the user.</param>
        /// <returns>Returns the serialized <see cref="GetAvailableAuthenticationFactorsResponse"/> as an asynchronous operation.</returns>
        public async Task<GetAvailableAuthenticationFactorsResponse> GetAvailableAuthenticationFactors(int userId)
        {
            return await GetResource<GetAvailableAuthenticationFactorsResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/auth_factors");
        }

        /// <summary>
        /// Use this API to enroll a user with a given authentication factor.
        /// If the authentication factor requires confirmation to complete, then the device will have an active state of false otherwise it will have an active state of true (corresponding to devices that are either pending confirmation or not)
        /// To change the active state of the device to true, the OTP device’s id would need to be supplied to the Activate a Factor endpoint.Then the `otp_code` would need to be sent to the Verify a Factor endpoint.
        /// </summary>
        /// <param name="userId">Set to the id of the user.</param>
        /// <param name="factorId">The identifier of the factor to enroll the user with.</param>
        /// <param name="displayName">A name for the users device</param>
        /// <param name="number">The phone number of the user in E.164 format.</param>
        /// <returns>Returns the serialized <see cref="EnrollAnAuthenticationFactorResponse"/> as an asynchronous operation.</returns>
        public async Task<EnrollAnAuthenticationFactorResponse> EnrollAnAuthenticationFactor(int userId, int factorId, string displayName, string number)
        {
            var request = new EnrollAnAuthenticationFactorRequest { FactorId = factorId, DisplayName = displayName, Number = number };
            return await PostResource<EnrollAnAuthenticationFactorResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/otp_devices", request);
        }

        /// <summary>
        /// Use this API to return a list of authentication factors registered to a particular user for multifactor authentication (MFA). The list includes devices that are enabled (used successfully for authentication at least once) or pending enablement (registered but never used).
        /// This API is typically used in a login workflow in which MFA is required, providing the user a selection of their registered MFA devices to choose from. The returned list represents the authentication factors that have been registered by the user on their Profile page or on the OneLogin login page or custom login page.
        /// </summary>
        /// <param name="userId">Set to the id of the user.</param>
        /// <returns>Returns the serialized <see cref="GetEnrolledAuthenticationFactorResponse"/> as an asynchronous operation.</returns>
        public async Task<GetEnrolledAuthenticationFactorResponse> GetEnrolledAuthenticationFactors(int userId)
        {
            return await GetResource<GetEnrolledAuthenticationFactorResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/auth_factors");
        }

        /// <summary>
        /// Use this API to return a list of authentication factors registered to a particular user for multifactor authentication (MFA). The list includes devices that are enabled (used successfully for authentication at least once) or pending enablement (registered but never used).
        /// This API is typically used in a login workflow in which MFA is required, providing the user a selection of their registered MFA devices to choose from. The returned list represents the authentication factors that have been registered by the user on their Profile page or on the OneLogin login page or custom login page.
        /// </summary>
        /// <param name="userId">Set to the id of the user.</param>
        /// <param name="deviceId">Set to the device_id of the MFA device.</param>
        /// <returns>Returns the serialized <see cref="GetEnrolledAuthenticationFactorResponse"/> as an asynchronous operation.</returns>
        public async Task<GetEnrolledAuthenticationFactorResponse> ActivateAnAuthenticationFactor(int userId, int deviceId)
        {
            return await GetResource<GetEnrolledAuthenticationFactorResponse>($"{Endpoints.ONELOGIN_USERS}/{userId}/otp_devices{deviceId}/trigger");
        }
    }
}
