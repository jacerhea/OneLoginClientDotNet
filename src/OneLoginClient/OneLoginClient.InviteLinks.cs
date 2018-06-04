using System;
using System.Collections.Generic;
using System.Text;

namespace OneLogin
{
    public class OneLoginClient : OneLoginClient
    {
        /// <summary>
        /// Generate an invite link for a user that you have already created in your OneLogin account.
        /// </summary>
        /// <param name="email">Set to the email address of the user that you want to generate an invite link for.</param>
        /// <returns>Provide the link to the user to enable her to set her password and then access your OneLogin portal.</returns>
        public async Task<GenerateInviteLinkResponse> GenerateInviteLink(string email)
        {
            return await PostResource<GenerateInviteLinkResponse>($"{Endpoints.ONELOGIN_INVITES}/get_invite_link", new GenerateInviteLinkRequest { Email = email });
        }


        /// <summary>
        /// Send an invite link to a user that you have already created in your OneLogin account.
        /// </summary>
        /// <param name="email">Set to the email address of the user that you want to generate an invite link for.</param>
        /// <param name="personalEmail">If you want to send the invite email to an email other than the one provided in  email, provide it here. The invite link will be sent to this address instead.</param>
        /// <returns>The user can click the link to set his password and access your OneLogin portal.</returns>
        public async Task<EmptyResponse> SendInviteLink(string email, string personalEmail = null)
        {
            return await PostResource<EmptyResponse>($"{Endpoints.ONELOGIN_INVITES}/send_invite_link", new SendInviteLinkRequest { Email = email, personal_email = personalEmail });
        }
    }
}
