using System.Runtime.Serialization;
using Newtonsoft.Json;
using OneLogin.Converters;

namespace OneLogin.Responses
{
    /// <summary>
    /// An contract for the common status schema returned from the API.
    /// </summary>
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


        /// <summary>
        /// The type of status.  Usually of type "success" for 200 "Ok" responses.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Additional information about the response which may include why it failed or if it succeeded.
        /// </summary>
        ///
        [JsonConverter(typeof(JsonConverterObjectToString))]
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
