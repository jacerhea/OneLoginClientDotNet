using System.Runtime.Serialization;

namespace OneLogin.Types
{
    /// <summary>
    /// Information about the device being used.
    /// </summary>
    [DataContract]
    public class Device
    {
        /// <summary>
        /// This device’s unique identifier
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}
