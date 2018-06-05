using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Request to set a users' password with a salt and hashed code.
    /// </summary>
    [DataContract]
    public class SetPasswordByIdUsingSaltAndSHA256
    {
        /// <summary>
        /// Set to the password value using a SHA-256-encoded value. If you are including your own password_salt value in your request, prepend the salt value to the cleartext password value before SHA-256-encoding it.
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// This value must match the password value.
        /// </summary>
        [DataMember(Name = "password_confirmation")]
        public string PasswordConfirmation { get; set; }

        /// <summary>
        /// Set to salt+sha256.
        /// </summary>
        [DataMember(Name = "password_algorithm")]
        public string PasswordAlgorithm { get; set; }


        /// <summary>
        /// Optional. If your password hash has been salted then you can provide the salt used in this param.
        /// This assumes that the salt was prepended to the password before doing the SHA256 hash. The API supports a salt value that is up to 40 characters long.
        /// </summary>
        [DataMember(Name = "password_salt")]
        public string PasswordSalt{ get; set; }
    }
}