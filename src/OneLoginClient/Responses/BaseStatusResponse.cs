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
        /// The status of the request.
        /// </summary>
        [DataMember(Name = "status")]
        public Status Status { get; set; }
    }
}
