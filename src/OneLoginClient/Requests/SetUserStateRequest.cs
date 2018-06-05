using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OneLogin.Types;

namespace OneLogin.Requests
{
    /// <summary>
    /// Set the State for a user.
    /// </summary>
    public class SetUserStateRequest
    {
        /// <summary>
        /// Represents the user’s stage in a process (such as user account approval). User state determines the possible statuses a user account can be in.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "state")]
        public State State { get; set; }
    }
}
