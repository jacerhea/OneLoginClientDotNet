using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    [DataContract]
    public abstract class BaseResponse<T> : BaseStatusResponse
    {
        /// <summary>
        /// Collection of data returned by the API service.
        /// </summary>
        [DataMember(Name = "Data")]
        public T[] Data { get; set; }
    }
}
