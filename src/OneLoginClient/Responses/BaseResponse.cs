using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// A base class for all responses that have returnable data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <inheritdoc cref="BaseStatusResponse" />
    [DataContract]
    public abstract class BaseResponse<T> : BaseStatusResponse
    {
        /// <summary>
        /// Collection of data returned by the API service.
        /// </summary>
        [DataMember(Name = "data")]
        public List<T> Data { get; set; }
    }
}
