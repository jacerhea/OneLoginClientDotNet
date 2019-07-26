using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Request to set a users's password with cleartext.
    /// </summary>
    [DataContract]
    public class SetPasswordByIdUsingCleartextRequest
    {
        /// <summary>
        /// Set to the password value using cleartext.
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Ensure that this value matches the password value exactly.
        /// </summary>
        [DataMember(Name = "password_confirmation")]
        public string PasswordConfirmation { get; set; }

        /// <summary>
        /// Defaults to false. This will validate the password against the users OneLogin password policy.
        /// </summary>
        [DataMember(Name = "validate_policy")]
        public bool ValidatePolicy { get; set; }
    }

}