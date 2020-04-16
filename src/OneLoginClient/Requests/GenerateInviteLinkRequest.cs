﻿using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Generate an invite link for a user that you have already created in your OneLogin account.
    /// </summary>
    [DataContract]
    public class GenerateInviteLinkRequest
    {
        /// <summary>
        /// Set to the user email address to generate an invite link.
        /// </summary>
        [DataMember(Name = "Email")]
        public string Email { get; set; }
    }
}
