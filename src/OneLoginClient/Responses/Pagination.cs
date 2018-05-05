using System.Runtime.Serialization;

namespace OneLogin.Responses
{
    /// <summary>
    /// When you call a resource API, the response message will include a pagination element like the one shown here:
    /// </summary>
    [DataContract]
    public class Pagination
    {
        /// <summary>
        /// You can use the before_cursor value as a query parameter to retrieve the previous page of results.
        /// </summary>
        [DataMember(Name = "before_cursor")]
        public string BeforeCursor { get; set; }

        /// <summary>
        /// You can use the after_cursor value as a query parameter to make a call to retrieve the next page, or set, of results.
        /// </summary>
        [DataMember(Name = "after_cursor")]
        public string AfterCursor { get; set; }

        /// <summary>
        /// The  previous_link value provides a premade request URL for your convenience.
        /// </summary>
        [DataMember(Name = "previous_link")]
        public string PreviousLink { get; set; }

        /// <summary>
        /// The next_link value provides a premade endpoint URL using the after_cursor value, for your convenience.
        /// </summary>
        [DataMember(Name = "next_link")]
        public string NextLink { get; set; }
    }
}
