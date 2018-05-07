using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// The base class for all responses that have a status element.
    /// </summary>
    [DataContract]
    public class BaseStatusResponse
    {
        /// <summary>
        /// A common status returned for all API calls.
        /// </summary>
        [DataMember(Name = "status")]
        public Status Status { get; set; }
    }
}
