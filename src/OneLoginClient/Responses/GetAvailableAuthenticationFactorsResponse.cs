using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    public class GetAvailableAuthenticationFactorsResponse : BaseStatusResponse
    {
        public AvailableAuthenticationContainer Data { get; set; }
    }

    public class AvailableAuthenticationContainer
    {
        public List<AuthenticationFactor> auth_factors { get; set; }
    }

    public class AuthenticationFactor
    {
        public string Name { get; set; }
        public int factor_id { get; set; }
    }
}
