using System.Runtime.Serialization;

namespace OneLogin.Types
{
    [DataContract]
    public class Source
    {
        /// <summary>
        /// A unique id that represents the source of the event.
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the source
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
