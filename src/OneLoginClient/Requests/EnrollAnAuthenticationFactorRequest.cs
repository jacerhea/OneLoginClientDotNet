using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// A request to enroll a user with a given authentication factor.
    /// </summary>
    [DataContract]
    public class EnrollAnAuthenticationFactorRequest
    {
        /// <summary>
        /// The identifier of the factor to enroll the user with.
        /// </summary>
        [DataMember(Name = "factor_id")]
        public int FactorId { get; set; }

        /// <summary>
        /// A name for the users device
        /// </summary>
        [DataMember(Name = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The phone number of the user in E.164 format.
        /// </summary>
        [DataMember(Name = "number")]
        public string Number { get; set; }
    }
}
