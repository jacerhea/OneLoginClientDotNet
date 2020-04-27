using System.Runtime.Serialization;
using OneLogin.Responses;
using OneLogin.Types;

namespace OneLogin.Requests
{
    [DataContract]
    public class TrackAnEventRequest
    {

        [DataMember(Name = "ip")]
        public string Ip { get; set; }

        [DataMember(Name = "verb")]
        public string Verb { get; set; }

        [DataMember(Name = "user_agent")]
        public string UserAgent { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "source")]
        public Source Source { get; set; }

        [DataMember(Name = "session")]
        public Session Session { get; set; }

        [DataMember(Name = "device")]
        public Device Device { get; set; }
    }




}
