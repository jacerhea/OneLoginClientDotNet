using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// A list of all OneLogin event types available to the Events API, providing event type names, event type IDs, and descriptions.
    /// </summary>
    public class GetEventTypesResponse : BaseResponse<EventType>
    {
    }

    [DataContract]
    public class EventType
    {
        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
