using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// A list of all OneLogin event types available to the Events API, providing event type names, event type IDs, and descriptions.
    /// </summary>
    public class GetEventTypesResponse : BaseResponse<EventType>
    {
    }

    /// <summary>
    /// A type of event available in the events API.
    /// </summary>
    [DataContract]
    public class EventType
    {
        /// <summary>
        /// Event types’s unique ID in OneLogin.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Describes the meaning of the event type.  This contains user replaceable values to localize to a particular event.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Event types’s unique name in OneLogin.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
