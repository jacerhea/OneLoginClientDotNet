using System.Runtime.Serialization;
using OneLogin.Descriptors;

namespace OneLogin.Requests
{
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/oauth20-tokens/generate-tokens")]
    [DataContract]
    public class GenerateTokenRequest
    {
        [DataMember(Name = "grant_type")]
        public string GrantType => "client_credentials";
    }
}
