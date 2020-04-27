using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Responses.Vigilance
{
    /// <summary>
    /// Use this API to get a real-time risk score for a user before completing a critical task or action.
    /// </summary>
    [DataContract]
    public class GetRiskScoreResponse
    {

        /// <summary>
        /// The risk score is a number between 0 and 1. Where 0 is low risk and 1 is the highest risk level possible.
        /// </summary>
        [DataMember(Name = "score")]
        public int Score { get; set; }

        [DataMember(Name = "triggers")]
        public IList<string> Triggers { get; set; }

        [DataMember(Name = "messages")]
        public IList<object> Messages { get; set; }
    }


}
