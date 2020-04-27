using System.Runtime.Serialization;

namespace OneLogin.Types
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class RiskScore
    {
        [DataMember(Name = "ip")]
        public string Ip { get; set; }

        [DataMember(Name = "user_agent")]
        public string UserAgent { get; set; }

        [DataMember(Name = "user")]
        public UserConcise User { get; set; }

        [DataMember(Name = "source")]
        public Source Source { get; set; }

        [DataMember(Name = "session")]
        public Session Session { get; set; }

        [DataMember(Name = "device")]
        public Device Device { get; set; }
    }
}
