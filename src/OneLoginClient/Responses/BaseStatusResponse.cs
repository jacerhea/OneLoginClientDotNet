using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    [DataContract]
    public class BaseStatusResponse
    {
        [DataMember(Name = "status")]
        public Status Status { get; set; }
    }
}
