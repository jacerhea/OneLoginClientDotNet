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
        public List<AvailableAuthenticationFactor> auth_factors { get; set; }
    }

    public class AvailableAuthenticationFactor
    {
        /// <summary>
        /// "Official" authentication factor name, as it appears to administrators in OneLogin.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name ="name")]
        public string Name { get; set; }

        /// <summary>
        /// Identifier for the factor which will be used for user enrollmen
        /// </summary>
        /// <value>The factor identifier.</value>
        [DataMember(Name = "factor_id")]
        public int FactorId { get; set; }
    }
}
