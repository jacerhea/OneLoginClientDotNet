using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// https://developers.onelogin.com/api-docs/1/oauth20-tokens/generate-tokens
    /// </summary>
    [DataContract]
    public class GenerateTokenRequest
    {
        [DataMember(Name = "grant_type")]
        public string GrantType => "client_credentials";
    }
}
