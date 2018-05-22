using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// Use this API to return a list of authentication factors that are available for user enrollment via API.
    /// </summary>
    [DataContract]
    public class GetAvailableAuthenticationFactorsResponse : BaseStatusResponse
    {
        [DataMember(Name = "data")]
        public AvailableAuthenticationContainer Data { get; set; }
    }


    /// <summary>
    /// Wrapper object for getting the list of authentication factors.
    /// </summary>
    [DataContract]
    public class AvailableAuthenticationContainer
    {
        /// <summary>
        /// Collection of all available authentication factors.
        /// </summary>
        [DataMember(Name = "auth_factors")]
        public List<AvailableAuthenticationFactor> AuthFactors { get; set; }
    }

    /// <summary>
    /// An available authentication factor.
    /// </summary>
    [DataContract]
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
