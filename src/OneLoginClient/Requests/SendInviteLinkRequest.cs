using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Generate an invite link for a user that you have already created in your OneLogin account.
    /// </summary>
    [DataContract]
    public class SendInviteLinkRequest
    {
        /// <summary>
        /// Set to the email address of the user that you want to generate an invite link for.
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// If you want to send the invite email to an email other than the one provided in  email, provide it here. The invite link will be sent to this address instead.
        /// </summary>
        [DataMember(Name = "personal_email")]
        public string PersonalEmail { get; set; }
    }
}
