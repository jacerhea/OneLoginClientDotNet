using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    public class GetEnrolledAuthenticationFactorResponse : BaseStatusResponse
    {
        public EnrolledAuthenticationFactorContainer Data { get; set; }
    }

    public class EnrolledAuthenticationFactorContainer
    {
        public List<OtpDevice> otp_devices { get; set; }
    }

    [DataContract]
    public class OtpDevice
    {
        public string type_display_name { get; set; }
        public bool active { get; set; }
        public string user_display_name { get; set; }

        [DataMember(Name = "default")]
        public bool Default { get; set; }

        public string phone_number { get; set; }
        public string auth_factor_name { get; set; }
        public int id { get; set; }
        public bool needs_trigger { get; set; }
    }
}
