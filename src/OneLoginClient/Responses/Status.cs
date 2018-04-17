using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    [DataContract]
    public class Status
    {
        /// <summary>
        /// Status Code greater than or equal to 400.
        /// </summary>
        [DataMember(Name = "error")]
        public bool Error { get; set; }

        /// <summary>
        /// Http Status Code
        /// </summary>
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
