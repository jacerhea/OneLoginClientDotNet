using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SetCustomAttributeRequest
    {
        /// <summary>
        /// One or more key value pairs composed of the custom attribute field shortname and the value that you want to set the field 
        /// </summary>
        [DataMember(Name = "custom_attributes")]
        public Dictionary<string, string> CustomAttributes { get; set; } = new Dictionary<string, string>();
    }
}
