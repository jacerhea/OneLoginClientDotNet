using System.Threading.Tasks;
using OneLogin.Requests;
using OneLogin.Responses;

namespace OneLogin
{
    public partial class OneLoginClient 
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
    }
}
