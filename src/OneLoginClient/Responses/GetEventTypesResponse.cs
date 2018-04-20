using System;
using System.Collections.Generic;
using System.Text;

namespace OneLogin.Responses
{
    public class GetEventTypesResponse : BaseResponse<EventType>
    {
    }

    public class EventType
    {
        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
    }
}
