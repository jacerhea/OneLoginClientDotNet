using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    [DataContract]
    public class Pagination
    {
        [DataMember(Name = "before_cursor")]
        public string BeforeCursor { get; set; }

        [DataMember(Name = "after_cursor")]
        public string AfterCursor { get; set; }

        [DataMember(Name = "previous_link")]
        public string PreviousLink { get; set; }

        [DataMember(Name = "next_link")]
        public string NextLink { get; set; }
    }
}
