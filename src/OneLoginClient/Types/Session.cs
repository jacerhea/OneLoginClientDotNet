using System.Runtime.Serialization;

namespace OneLogin.Types
{
    [DataContract]
    public class Session
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}
