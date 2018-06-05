using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// Response message containing the status of the request.
    /// </summary>
    [DataContract]
    public class EmptyResponse : BaseStatusResponse
    {
    }
}
