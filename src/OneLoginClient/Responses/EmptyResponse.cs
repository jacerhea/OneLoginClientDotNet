using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// Response message containing the status of the request.
    /// </summary>
    [DataContract]
    public class EmptyResponse
    {
        /// <summary>
        /// The status of the request.
        /// </summary>
        [DataMember(Name = "status")]
        public Status Status { get; set; }
    }
}
